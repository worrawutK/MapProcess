Imports Microsoft.VisualBasic

Public Class clsMap
    Const HEADER As String = "clsMap"

    Public Shared Function getMapData(ByVal strPathOrZipfile As String) As clsMapData

        Dim tempDir As String = ""
        Dim mapclass As New clsMapData
        Dim strFileName As String = strPathOrZipfile.Substring(strPathOrZipfile.LastIndexOf("\") + 1, _
                                    strPathOrZipfile.Length - strPathOrZipfile.LastIndexOf("\") - 1)
        strFileName = strFileName.ToLower.Replace(".zip", "")

        Try
            If strPathOrZipfile.ToLower Like "*.zip" Then
                tempDir = clsFileOpe.Temp_mappath_root()
                If Not System.IO.Directory.Exists(tempDir) Then System.IO.Directory.CreateDirectory(tempDir)
                Do
                    tempDir = tempDir & "\" & Now.Ticks.ToString
                    If Not System.IO.Directory.Exists(tempDir) Then Exit Do
                Loop
                System.IO.Directory.CreateDirectory(tempDir)

                If clsZipCSharp.unZiptoFolder(strPathOrZipfile, tempDir, True) = False Then
                    Throw New System.Exception("Unzip to folder error:[" & strPathOrZipfile & "]to[" & tempDir & "]")
                End If
                strPathOrZipfile = tempDir & "\" & strFileName
            Else
                If Not System.IO.Directory.Exists(strPathOrZipfile) Then
                    Throw New System.Exception("Path not exist:[" & strPathOrZipfile & "]")
                End If
            End If

            If mapclass.readMapData(strPathOrZipfile) = False Then
                If tempDir <> "" Then
                    clsFileOpe.deleteFolderAll(tempDir)
                End If
                Return Nothing
            End If
            If tempDir <> "" Then
                clsFileOpe.deleteFolderAll(tempDir)
            End If

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:clsMap/isValid:[" & strPathOrZipfile & "]" & _
               vbCrLf & ex.ToString, HEADER)
            If tempDir <> "" Then
                clsFileOpe.deleteFolderAll(tempDir)
            End If
            Return Nothing
        End Try
        Return mapclass
    End Function
End Class
