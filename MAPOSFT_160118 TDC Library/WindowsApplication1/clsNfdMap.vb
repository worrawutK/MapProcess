Imports System.IO
Public Class clsNfdMap
    Const HEADER As String = "clsNfdMap"



    Public Shared Function GetProberInfo(ByVal strProberIPAdress As String) As String

        '    'GetProberInfo:	[※]IPBAのStatusを確認する 

        '    'return value 
        '    'Lot Waiting
        '    'Error


        Dim strErrSig As String = "GetProberInfo:" & strProberIPAdress & ":"

        Try
            Dim ans As String = ""

            '　	[※]Infoファイルを取得
            Dim strInfoFile = "\\" & strProberIPAdress & "\" & "DATA\Info.txt"

            '   LOTID.txt読込
            If Not System.IO.File.Exists(strInfoFile) Then
                clsErrorLog.addlogWT("Error:isProberwaiting/InfoFileNotExist:" & strErrSig, HEADER)
                Return "Error:isProberwaiting/InfoFileNotExist:" & strErrSig
            End If
            Dim strInfo As String = My.Computer.FileSystem.ReadAllText(strInfoFile, System.Text.Encoding.Default)
            strInfo = strInfo.Replace(vbCr, "").Replace(vbLf, "")
            Return strInfo

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsNfdMap/isProberWaiting" & strErrSig, HEADER)
            Return "Error:" & ex.ToString
        Finally
        End Try
    End Function


    Public Shared Function zipFiles(ByVal strSourceDir As String, ByVal strDestinFile As String) As Boolean

        Dim strSourceDirTmp = System.IO.Directory.GetCurrentDirectory & "\TempZip"
        If System.IO.Directory.Exists(strSourceDirTmp) Then
            deleteFolderAll(strSourceDirTmp)
            If System.IO.Directory.Exists(strSourceDirTmp) Then
                clsErrorLog.addlogWT("Error:clsNfdMap/CanNotDeleteFile", HEADER)
                Return "Error:clsNfdMap/CanNotDeleteFile"
            End If
        End If
        createFolder(strSourceDirTmp)

        '	zipFiles	tmpにzip生成->tmpcopy->元ファイルをdeleteFile
        If System.IO.File.Exists(strDestinFile) Then
            clsErrorLog.addlogWT("Error:clsNfdMap/zipFiles_0:[" & strSourceDir & "]to[" & strDestinFile & "]" & _
               "[DestinDir exist]" & vbCrLf, HEADER)
            Return False
        End If
        If Not System.IO.Directory.Exists(strSourceDir) Then
            clsErrorLog.addlogWT("Error:clsNfdMap/zipFiles_0:[" & strSourceDir & "]to[" & strDestinFile & "]" & _
               "[SourceFile not exist]" & vbCrLf, HEADER)
            Return False
        End If
        Dim fas As FileAttribute
        Try
            '   'TempZipフォルダーに移動
            ' Dim fs As String() = System.IO.Directory.GetFiles(strSourceDir,"*.*)
            For Each f As String In System.IO.Directory.GetFiles(strSourceDir)
                fas = File.GetAttributes(f)
                If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
                    System.IO.File.Copy(f, strSourceDirTmp & "\" & System.IO.Path.GetFileName(f), True)
                    'System.IO.File.Delete(f)
                End If
            Next
            clsZipCSharp.createZipFromFolder(strSourceDirTmp, strDestinFile)
            If Not System.IO.File.Exists(strDestinFile) Then Throw New System.Exception
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:clsNfdMap/zipFiles_1:[" & strSourceDir & "]to[" & strDestinFile & "]" & _
                vbCrLf & ex.ToString, HEADER)
            If System.IO.File.Exists(strDestinFile) Then System.IO.File.Delete(strDestinFile)
            Return False
        End Try

        Try
            deleteFolderAll(strSourceDirTmp)
            If System.IO.Directory.Exists(strSourceDirTmp) Then
                clsErrorLog.addlogWT("Error:clsNfdMap/CanNotDeleteFile", HEADER)
                Return "Error:clsNfdMap/CanNotDeleteFile"
            End If
            Dim strFiles As String() = System.IO.Directory.GetFiles(strSourceDir)
            For Each strfile As String In strFiles
                fas = File.GetAttributes(strfile)
                If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
                    If deleteFile(strfile) = False Then Throw New System.Exception
                End If
            Next
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:clsNfdMap/zipFiles_2:[" & strSourceDir & "]to[" & strDestinFile & "]" & _
                vbCrLf & ex.ToString, HEADER)
            Return False
        End Try
        Return True
    End Function

    Public Shared Function unzipFiles(ByVal strSourcefile As String, ByVal strDestinDir As String) As Boolean
        '	unzipFiles	tmpにunzip生成->tmpcopy->元ファイルをdeleteFile
        If Not System.IO.Directory.Exists(strDestinDir) Then
            clsErrorLog.addlogWT("Error:clsNfdMap/unzipFiles_0:[" & strSourcefile & "]to[" & strDestinDir & "]" & _
               "[DestinDir not exist]" & vbCrLf, HEADER)
            Return False
        End If
        If Not System.IO.File.Exists(strSourcefile) Then
            clsErrorLog.addlogWT("Error:clsNfdMap/unzipFiles_0:[" & strSourcefile & "]to[" & strDestinDir & "]" & _
               "[SourceFile not exist]" & vbCrLf, HEADER)
            Return False
        End If
        Try
            If clsZipCSharp.unZiptoFolder(strSourcefile, strDestinDir, True) = False Then Throw New System.Exception
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:clsNfdMap/unzipFiles_1:[" & strSourcefile & "]to[" & strDestinDir & "]" & _
               vbCrLf & ex.ToString, HEADER)
            Dim strFiles As String() = System.IO.Directory.GetFiles(strDestinDir)
            For Each strfile As String In strFiles
                If deleteFile(strfile) = False Then Throw New System.Exception
            Next
            DeleteDirectory(New System.IO.DirectoryInfo(strDestinDir))

            Return False
        End Try

        Try
            If deleteFile(strSourcefile) = False Then Throw New System.Exception
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:clsNfdMap/unzipFiles_2:[" & strSourcefile & "]to[" & strDestinDir & "]" & _
                vbCrLf & ex.ToString, HEADER)

            Return False
        End Try
        Return True
    End Function

    Private Shared Sub DeleteDirectory(ByVal hDirectoryInfo As System.IO.DirectoryInfo)

        If Not hDirectoryInfo.Exists Then Exit Sub
        ' すべてのファイルの読み取り専用属性を解除する
        For Each hFileInfo As System.IO.FileInfo In hDirectoryInfo.GetFiles()
            If (hFileInfo.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
                hFileInfo.Attributes = System.IO.FileAttributes.Normal
            End If
        Next hFileInfo

        ' サブディレクトリ内の読み取り専用属性を解除する (再帰)
        For Each hDirInfo As System.IO.DirectoryInfo In hDirectoryInfo.GetDirectories()
            DeleteDirectory(hDirInfo)

        Next hDirInfo

        ' このディレクトリの読み取り専用属性を解除する
        If (hDirectoryInfo.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
            hDirectoryInfo.Attributes = System.IO.FileAttributes.Directory
        End If

        ' このディレクトリを削除する
        hDirectoryInfo.Delete(True)
    End Sub


    Private Shared Function deleteFolderAll(ByVal strDir As String) As Boolean

        If Not System.IO.Directory.Exists(strDir) Then
            'clsErrorLog.addlogWT("Error:clsNfdMap/deleteFolderAll0:[" & strDir & "]" & _
            '     "[Dir not exist]" & vbCrLf, HEADER)
            Return False
        End If

        Try
            If System.IO.Directory.GetFiles(strDir).Length > 0 Then
                For Each strfile As String In System.IO.Directory.GetFiles(strDir)
                    If deleteFile(strfile) = False Then Throw New System.Exception
                Next
            End If
            System.IO.Directory.Delete(strDir)
            If System.IO.Directory.Exists(strDir) Then Throw New System.Exception

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:clsNfdMap/deleteFolderAll:[" & strDir & "]" & _
                vbCrLf & ex.ToString, HEADER)
            If Not System.IO.Directory.Exists(strDir) Then System.IO.Directory.CreateDirectory(strDir)
            Return False
        End Try
        Return True
    End Function

    Public Shared Function deleteFile(ByVal strFile As String) As Boolean

        Dim originalFile As String = strFile

        Try
            If Not System.IO.File.Exists(strFile) Then Return False
            System.IO.File.Delete(strFile)
            If System.IO.File.Exists(strFile) Then Throw New System.Exception

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:clsNfdMap/deleteFile:[" & strFile & "]" & _
               vbCrLf & ex.ToString, HEADER)
            Return False
        End Try
        Return True
    End Function
    Private Shared Function createFolder(ByVal strDir As String) As Boolean

        Try
            If System.IO.Directory.Exists(strDir) Then Throw New System.Exception
            System.IO.Directory.CreateDirectory(strDir)
            If Not System.IO.Directory.Exists(strDir) Then Throw New System.Exception

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:clsNfdMap/createFolder:[" & strDir & "]" & _
             vbCrLf & ex.ToString, HEADER)
            If System.IO.Directory.Exists(strDir) Then System.IO.Directory.Delete(strDir)
            Return False
        End Try
        Return True
    End Function


    Public Shared Function copyFileToDir(ByVal strSourceFile As String, ByVal strDestinDir As String) As Boolean

        Dim originalFile As String = strDestinDir & "\" & System.IO.Path.GetFileName(strSourceFile)
        Try
            If Not System.IO.File.Exists(strSourceFile) Then Throw New System.Exception
            If System.IO.File.Exists(originalFile) Then
                If deleteFile(originalFile) = False Then Throw New System.Exception
            End If
            System.IO.File.Copy(strSourceFile, originalFile)
            If Not System.IO.File.Exists(originalFile) Then Throw New System.Exception

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:clsNfdMap/copyFileToDir:[" & strSourceFile & "]to[" & strDestinDir & "]" & _
                vbCrLf & ex.ToString, HEADER)
            If System.IO.File.Exists(originalFile) Then System.IO.File.Delete(originalFile)
            Return False
        End Try
        Return True
    End Function


    
End Class
