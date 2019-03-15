'ver1.01 2011/06/30 add zip lastWrite time 
'        2012/10/15 throw exception to upperclass
'        2012/10/16 .. add at simple sanity check, too        

Imports ICSharpCode.SharpZipLib.Core
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Tar
'Public Class clsErrorLog
'    Public Shared Sub addlogwt(ByVal strC As String)
'        'null
'    End Sub
'End Class

Public Class clsZipCSharp
    Public Shared Sub createZipFromFolder(ByVal sourceDir As String, ByVal targetFile As String)


        ' Simple sanity checks
        trimYen(sourceDir)
        If Not System.IO.Directory.Exists(sourceDir) Then
            clsErrorLog.addlogWT("clsZipCSharp_createZipFromFolder:Directory not found@" & sourceDir)
            Throw New System.Exception("clsZipCSharp_createZipFromFolder:Directory not found@" & sourceDir)
        End If

        If targetFile.Length = 0 Then
            clsErrorLog.addlogWT("clsZipCSharp_createZipFromFolder:No name specified")
            Throw New System.Exception("clsZipCSharp_createZipFromFolder:No name specified")
        End If

        Dim astrFileNames() As String = System.IO.Directory.GetFiles(sourceDir)
        Dim strmZipOutputStream As ZipOutputStream

        strmZipOutputStream = New ZipOutputStream(System.IO.File.Create(targetFile))

        Try

            REM Compression Level: 0-9
            REM 0: no(Compression)
            REM 9: maximum compression
            strmZipOutputStream.SetLevel(9)

            Dim strFile As String
            Dim abyBuffer(4096) As Byte

            For Each strFile In astrFileNames
                Dim dt As DateTime = Now
                Try
                    dt = System.IO.File.GetLastWriteTime(strFile)
                Catch ex As Exception
                End Try
                
                Dim strmFile As System.IO.FileStream = Nothing
                Try
                    strmFile = System.IO.File.OpenRead(strFile)

                    Dim objZipEntry As ZipEntry = New ZipEntry(System.IO.Path.GetFileName(strFile))

                    objZipEntry.DateTime = dt
                    objZipEntry.Size = strmFile.Length

                    strmZipOutputStream.PutNextEntry(objZipEntry)
                    StreamUtils.Copy(strmFile, strmZipOutputStream, abyBuffer)
                Catch ex As Exception
                    Throw ex
                Finally
                    If Not strmFile Is Nothing Then
                        strmFile.Close()
                    End If
                End Try
            Next

            strmZipOutputStream.Finish()

        Catch ex As Exception
            Throw ex
        Finally
            strmZipOutputStream.Close()
        End Try

    End Sub

    Public Shared Sub createZipFromFiles(ByVal sourceFiles As System.Collections.Generic.List(Of String), ByVal targetFile As String)


        If targetFile.Length = 0 Then
            clsErrorLog.addlogWT("clsZipCSharp_createZipFromFolder:No name specified")
            Throw New System.Exception("clsZipCSharp_createZipFromFolder:No name specified")
        End If

        Dim strmZipOutputStream As ZipOutputStream

        strmZipOutputStream = New ZipOutputStream(System.IO.File.Create(targetFile))

        Try

            REM Compression Level: 0-9
            REM 0: no(Compression)
            REM 9: maximum compression
            strmZipOutputStream.SetLevel(9)

            Dim strFile As String
            Dim abyBuffer(4096) As Byte

            For Each strFile In sourceFiles
                Dim dt As DateTime = Now
                Try
                    dt = System.IO.File.GetLastWriteTime(strFile)
                Catch ex As Exception
                End Try

                Dim strmFile As System.IO.FileStream = System.IO.File.OpenRead(strFile)
                Try

                    Dim objZipEntry As ZipEntry = New ZipEntry(System.IO.Path.GetFileName(strFile))

                    objZipEntry.DateTime = dt
                    objZipEntry.Size = strmFile.Length

                    strmZipOutputStream.PutNextEntry(objZipEntry)
                    StreamUtils.Copy(strmFile, strmZipOutputStream, abyBuffer)
                Catch ex As Exception
                    Throw ex
                Finally
                    strmFile.Close()
                End Try
            Next

            strmZipOutputStream.Finish()

        Catch ex As Exception
            Throw ex
        Finally
            strmZipOutputStream.Close()
        End Try

    End Sub

    Public Shared Function unZiptoFolder(ByVal sourceFile As String, ByVal targetDir As String, _
    Optional ByVal dontCreateFolder As Boolean = False) As Boolean

        ' Simple sanity checks
        If Not System.IO.File.Exists(sourceFile) Then
            clsErrorLog.addlogWT("clsZipCSharp_unZiptoFolder:File not found@" & sourceFile)
            Throw New System.Exception("clsZipCSharp_unZiptoFolder:File not found@" & sourceFile)
        End If
        trimYen(targetDir)
        If Not System.IO.Directory.Exists(targetDir) Then
            clsErrorLog.addlogWT("clsZipCSharp_unZiptoFolder:dir not found@" & targetDir)
            Throw New System.Exception("clsZipCSharp_unZiptoFolder:dir not found@" & targetDir)
        End If

        Dim localzone As TimeZone = TimeZone.CurrentTimeZone

        Dim s As New ZipInputStream(System.IO.File.OpenRead(sourceFile))

        Try
            Dim theEntry As ZipEntry
            Do
                theEntry = s.GetNextEntry
                If theEntry Is Nothing Then Exit Do

                'Console.WriteLine(theEntry.Name)

                Dim directoryName As String = System.IO.Path.GetDirectoryName(theEntry.Name)
                Dim fileName As String = System.IO.Path.GetFileName(theEntry.Name)

                renameColon(directoryName)
                If dontCreateFolder Then
                    directoryName = targetDir
                Else
                    directoryName = targetDir & "\" & directoryName '相対PATH
                End If
                trimYen(directoryName)

                ' create directory
                If (directoryName.Length > 0) Then
                    System.IO.Directory.CreateDirectory(directoryName)
                End If

                If Not fileName Is Nothing AndAlso fileName <> "" Then
                    
                    Dim streamWriter As System.IO.FileStream = System.IO.File.Create(directoryName & "\" & fileName)
                    Dim size As Integer = 2048
                    Dim data(2048) As Byte
                    Do
                        size = s.Read(data, 0, data.Length)
                        If (size > 0) Then
                            streamWriter.Write(data, 0, size)
                        Else
                            Exit Do
                        End If
                    Loop
                    streamWriter.Flush()
                    streamWriter.Close()
                    'Extra data: not sure but Lhaca has it and it set 'Local timezone'
                    If theEntry.ExtraData Is Nothing Then
                        System.IO.File.SetLastWriteTime(directoryName & "\" & fileName, theEntry.DateTime)
                    Else
                        System.IO.File.SetLastWriteTime(directoryName & "\" & fileName, localzone.ToLocalTime(theEntry.DateTime))
                    End If
                End If
            Loop
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:unZiptoFolder/" & sourceFile & " to " & targetDir & ":" & ex.ToString)
            Throw New System.Exception("Error:unZiptoFolder/" & sourceFile & " to " & targetDir & ":" & ex.ToString)
        End Try
        Return True
    End Function

    Public Shared Function getZipFilelist(ByVal sourceFile As String) As System.Collections.Generic.List(Of String)
        Dim ans As New System.Collections.Generic.List(Of String)

        ' Simple sanity checks
        If Not System.IO.File.Exists(sourceFile) Then
            clsErrorLog.addlogWT("clsZipCSharp_unZiptoFolder:File not found@" & sourceFile)
            Throw New System.Exception("clsZipCSharp_unZiptoFolder:File not found@" & sourceFile)
        End If

        'Dim localzone As TimeZone = TimeZone.CurrentTimeZone
        Dim s As New ZipInputStream(System.IO.File.OpenRead(sourceFile))

        Dim theEntry As ZipEntry
        Do
            theEntry = s.GetNextEntry
            If theEntry Is Nothing Then Exit Do
            ans.Add(theEntry.Name)
        Loop

        Return ans
    End Function

    Public Shared Sub unTartoFolder(ByVal sourceFile As String, ByVal targetDir As String)

        ' Simple sanity checks
        If Not System.IO.File.Exists(sourceFile) Then
            clsErrorLog.addlogWT("clsZipCSharp_unTartoFolder:File not found@" & sourceFile)
            Throw New System.Exception("clsZipCSharp_unTartoFolder:File not found@" & sourceFile)
        End If
        trimYen(targetDir)
        If Not System.IO.Directory.Exists(targetDir) Then
            clsErrorLog.addlogWT("clsZipCSharp_unTartoFolder:dir not found@" & targetDir)
            Throw New System.Exception("clsZipCSharp_unTartoFolder:dir not found@" & targetDir)
        End If

        Dim localzone As TimeZone = TimeZone.CurrentTimeZone

        Dim s As New TarInputStream(System.IO.File.OpenRead(sourceFile))

        Dim theEntry As TarEntry
        'Dim tbd As New frmTimeLogger
        'tbd.Mode(1)
        Do
            'tbd.Mode(2)
            theEntry = s.GetNextEntry
            If theEntry Is Nothing Then Exit Do

            'Console.WriteLine(theEntry.Name)

            Dim directoryName As String = System.IO.Path.GetDirectoryName(theEntry.Name)
            Dim fileName As String = System.IO.Path.GetFileName(theEntry.Name)

            renameColon(directoryName)
            directoryName = targetDir & "\" & directoryName '相対PATH
            trimYen(directoryName)
            'tbd.Mode(3)


            ' create directory
            If (directoryName.Length > 0) Then

                System.IO.Directory.CreateDirectory(directoryName)
            End If
            'tbd.Mode(4)

            If Not fileName Is Nothing Then
                'Dim data(theEntry.Size) As Byte
                'Dim dummy As Long = s.Read(data, 0, theEntry.Size)
                'My.Computer.FileSystem.WriteAllBytes(directoryName & "\" & fileName, data, False)
                Dim streamWriter As System.IO.FileStream = System.IO.File.Create(directoryName & "\" & fileName)
                Dim data(4095) As Byte
                Dim size As Integer = data.Length
                Do
                    'tbd.Mode(5)
                    size = s.Read(data, 0, data.Length)
                    'tbd.Mode(6)
                    If (size > 0) Then
                        streamWriter.Write(data, 0, size)
                    Else
                        Exit Do
                    End If
                    'tbd.Mode(7)
                Loop
                streamWriter.Flush()
                streamWriter.Close()
                System.IO.File.SetLastWriteTime(directoryName & "\" & fileName, _
                    localzone.ToLocalTime(theEntry.ModTime))
            End If
            'tbd.Mode(8)
        Loop

        s.Close()
        'tbd.Mode(9)
        'tbd.ShowResult()

    End Sub

    Private Shared Sub trimYen(ByRef dir As String)
        If dir.Substring(dir.Length - 1, 1) = "\" Then dir = dir.Substring(0, dir.Length - 1)
    End Sub
    Private Shared Sub renameColon(ByRef dir As String)
        dir = dir.Replace(":"c, "_"c)
    End Sub

End Class
