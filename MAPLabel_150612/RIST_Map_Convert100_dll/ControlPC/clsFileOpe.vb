'special function for File Operation
'
'
'
'
'

Imports Microsoft.VisualBasic
Imports System.IO
Public Class clsFileOpe
    Const HEADER As String = "clsFileOpe"
    Friend Shared Langtran As LanguageTranslationClass
    Public Shared Function createFolder(ByVal strDir As String) As Boolean

        Try
            If System.IO.Directory.Exists(strDir) Then Throw New System.Exception
            System.IO.Directory.CreateDirectory(strDir)
            If Not System.IO.Directory.Exists(strDir) Then Throw New System.Exception

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & "/createFolder:[" & strDir & "]" & ex.ToString, HEADER)
            If System.IO.Directory.Exists(strDir) Then System.IO.Directory.Delete(strDir)
            Return False
        End Try
        Return True
    End Function

    Public Shared Function deleteFolder(ByVal strDir As String) As Boolean

        If Not System.IO.Directory.Exists(strDir) Then
            clsErrorLog.addlogWT("Error:" & HEADER & "/deleteFolder0:[" & strDir & "]" & "[Dir not exist]", HEADER)
            Return False
        End If

        Try
            If System.IO.Directory.GetFiles(strDir).Length > 0 Then Throw New System.Exception
            System.IO.Directory.Delete(strDir)
            If System.IO.Directory.Exists(strDir) Then Throw New System.Exception

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & "/deleteFolder:[" & strDir & "]" & ex.ToString, HEADER)
            If Not System.IO.Directory.Exists(strDir) Then System.IO.Directory.CreateDirectory(strDir)
            Return False
        End Try
        Return True
    End Function

    Public Shared Function deleteFolderAll(ByVal strDir As String) As Boolean

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
            System.IO.Directory.Delete(strDir, True)
            If System.IO.Directory.Exists(strDir) Then Throw New System.Exception

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & "/deleteFolderAll:[" & strDir & "]" & ex.ToString, HEADER)
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
            clsErrorLog.addlogWT("Error:" & HEADER & "/deleteFile:[" & strFile & "]" & ex.ToString, HEADER)
            Return False
        End Try
        Return True
    End Function

    Public Shared Function copyFileToFile(ByVal strSourceFile As String, ByVal strDestinFile As String) As Boolean

        Dim originalFile As String = strDestinFile

        Try
            If Not System.IO.File.Exists(strSourceFile) Then Throw New System.Exception
            If System.IO.File.Exists(strDestinFile) Then
                If deleteFile(strDestinFile) = False Then Throw New System.Exception
            End If
            System.IO.File.Copy(strSourceFile, strDestinFile)
            If Not System.IO.File.Exists(strDestinFile) Then Throw New System.Exception

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & "/copyFileToFile:[" & strSourceFile & "]to[" & strDestinFile & "]" & ex.ToString, HEADER)
            If System.IO.File.Exists(originalFile) Then System.IO.File.Delete(originalFile)
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
            clsErrorLog.addlogWT("Error:" & HEADER & "/copyFileToDir:[" & strSourceFile & "]to[" & strDestinDir & "]" & ex.ToString, HEADER)
            If System.IO.File.Exists(originalFile) Then System.IO.File.Delete(originalFile)
            Return False
        End Try
        Return True
    End Function

    Public Shared Function zipFiles(ByVal strSourceDir As String, ByVal strDestinFile As String) As Boolean

        Dim strSourceDirTmp = System.IO.Directory.GetCurrentDirectory & "\TempZip"
        If System.IO.Directory.Exists(strSourceDirTmp) Then
            deleteFolderAll(strSourceDirTmp)
            If System.IO.Directory.Exists(strSourceDirTmp) Then
                clsErrorLog.addlogWT("Error:" & HEADER & "/CanNotDeleteFile", HEADER)
                Return "Error:CanNotDeleteFile"
            End If
        End If
        createFolder(strSourceDirTmp)

        '	zipFiles	tmpにzip生成->tmpcopy->元ファイルをdeleteFile
        If System.IO.File.Exists(strDestinFile) Then
            clsErrorLog.addlogWT("Error:" & HEADER & "/zipFiles_0:[" & strSourceDir & "]to[" & strDestinFile & "]" & _
               "[DestinDir exist]", HEADER)
            Return False
        End If
        If Not System.IO.Directory.Exists(strSourceDir) Then
            clsErrorLog.addlogWT("Error:" & HEADER & "/zipFiles_0:[" & strSourceDir & "]to[" & strDestinFile & "]" & _
               "[SourceFile not exist]", HEADER)
            Return False
        End If
        Dim fas As FileAttribute

        Try
            '   'TempZipフォルダーに移動
            'Dim fs As String() = System.IO.Directory.GetFiles(strSourceDir, "*.*")
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
            clsErrorLog.addlogWT("Error:" & HEADER & "/zipFiles_1:[" & strSourceDir & "]to[" & strDestinFile & "]" & _
                ex.ToString, HEADER)
            If System.IO.File.Exists(strDestinFile) Then System.IO.File.Delete(strDestinFile)
            Return False
        End Try

        Try
            deleteFolderAll(strSourceDirTmp)
            If System.IO.Directory.Exists(strSourceDirTmp) Then
                clsErrorLog.addlogWT("Error:" & HEADER & "/CanNotDeleteFile", HEADER)
                Return "Error:CanNotDeleteFile"
            End If
            Dim strFiles As String() = System.IO.Directory.GetFiles(strSourceDir)
            For Each strfile As String In strFiles
                fas = File.GetAttributes(strfile)
                If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
                    If deleteFile(strfile) = False Then Throw New System.Exception
                End If
            Next
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & "/zipFiles_2:[" & strSourceDir & "]to[" & strDestinFile & "]" & _
                ex.ToString, HEADER)
            Return False
        End Try
        Return True
    End Function

    Public Shared Function unzipFiles(ByVal strSourcefile As String, ByVal strDestinDir As String) As Boolean
        '	unzipFiles	tmpにunzip生成->tmpcopy->元ファイルをdeleteFile
        If Not System.IO.Directory.Exists(strDestinDir) Then
            clsErrorLog.addlogWT("Error:" & HEADER & "/unzipFiles_0:[" & strSourcefile & "]to[" & strDestinDir & "]" & _
               "[DestinDir not exist]", HEADER)
            Return False
        End If
        If Not System.IO.File.Exists(strSourcefile) Then
            clsErrorLog.addlogWT("Error:" & HEADER & "/unzipFiles_0:[" & strSourcefile & "]to[" & strDestinDir & "]" & _
               "[SourceFile not exist]", HEADER)
            Return False
        End If

        Try
            If clsZipCSharp.unZiptoFolder(strSourcefile, strDestinDir, True) = False Then Throw New System.Exception
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & "/unzipFiles_1:[" & strSourcefile & "]to[" & strDestinDir & "]" & _
                ex.ToString, HEADER)
            Dim strFiles As String() = System.IO.Directory.GetFiles(strDestinDir)
            For Each strfile As String In strFiles
                If deleteFile(strfile) = False Then Throw New System.Exception
            Next
            DeleteDirectory(strDestinDir)
            Return False
        End Try

        Try
            If deleteFile(strSourcefile) = False Then Throw New System.Exception
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & "/unzipFiles_2:[" & strSourcefile & "]to[" & strDestinDir & "]" & _
                ex.ToString, HEADER)

            Return False
        End Try
        Return True
    End Function

    Public Shared Sub DeleteDirectory(ByVal stDirPath As String)

        DeleteDirectory(New System.IO.DirectoryInfo(stDirPath))
    End Sub

    Public Shared Sub DeleteDirectory(ByVal hDirectoryInfo As System.IO.DirectoryInfo)

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

    Public Shared Sub appConfigValueSet(ByVal strKey As String, ByVal strValue As String)
        
        Dim name As String = My.Application.Info.AssemblyName

        Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim appConfigPath As String
        appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + "\" & name & ".exe.config"
        Dim doc As System.Xml.XmlDocument = New System.Xml.XmlDocument
        doc.Load(appConfigPath)
        Dim node As System.Xml.XmlNode = doc("configuration")("appSettings")

        Dim n As System.Xml.XmlNode
        For Each n In doc("configuration")("appSettings")
            If n.Name = "add" Then
                If n.Attributes.GetNamedItem("key").Value = strKey Then
                    n.Attributes.GetNamedItem("value").Value = strValue
                End If
            End If
        Next
        doc.Save(appConfigPath)
    End Sub

    Private Shared Function ChkExistReadOnly(ByVal strDirPath As String) As Boolean
        'ReadOnly以外のファイルがあれば False
        'ReadOnlyのみなら or ファイルなければ True
        Dim fas As FileAttribute
        'Dim fs As String() = System.IO.Directory.GetFiles(strDirPath, "*.*")
        For Each f As String In System.IO.Directory.GetFiles(strDirPath)
            fas = File.GetAttributes(f)
            If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
                Return False
            End If
        Next
        Return True
    End Function

    'Public Shared Function Marge(ByVal strStockFolderParent As String, ByVal strStockFolderChild As String, _
    '                       ByVal strStockFileP As String, ByVal strStockFileC As String, ByVal strLotNo As String) As String

    '    'MargeLot:

    '    '       両方とも存在しなければNG
    '    '       両方ともzip状態(Stock)に限る
    '    '       仮フォルダ(親)(子）に展開
    '    '       W-NO-XX.DATを仮フォルダ(親）に移動
    '    '       仮フォルダ(親）　zipアップロード
    '    '       子ロットのデータレコードDelete()

    '    'return value 
    '    '"True": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[Marge" & strStockFileP & "/" & strStockFileC & "/" & _
    '        strLotNo & "]:"
    '    Dim strStockFileParent As String = strStockFolderParent & "\" & strStockFileP & ".zip"
    '    Dim strStockFileChild As String = strStockFolderChild & "\" & strStockFileC & ".zip"
    '    Dim strTempPathParent As String = clsShareSub.Temp_Marge_root() & "\Temp\Parent"
    '    Dim strTempPathChild As String = clsShareSub.Temp_Marge_root() & "\Temp\Child"

    '    Dim strZipfile As String = ""

    '    Try
    '        If Not System.IO.Directory.Exists(strTempPathParent) Then createFolder(strTempPathParent)
    '        If Not System.IO.Directory.Exists(strTempPathChild) Then createFolder(strTempPathChild)

    '        Dim ans As String = ""

    '        Dim parentMapclass As MapData = Nothing
    '        Dim childMapclass As MapData = Nothing
    '        '       両方ともzip状態(Stock)に限る
    '        If System.IO.File.Exists(strStockFileParent) Then
    '            If System.IO.File.Exists(strStockFileParent & ".bak") Then
    '                deleteFile(strStockFileParent & ".bak")
    '                If System.IO.File.Exists(strStockFileParent & ".bak") Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CanNotDeleteFile:" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CanNotDeleteFile:" & strErrSig
    '                End If
    '            End If
    '            If System.IO.File.Exists(strStockFileParent) Then
    '                '       親Map読み込み
    '                parentMapclass = clsMapDataValidateCheck.getMapdata(strStockFileParent)
    '                If parentMapclass Is Nothing Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CannotReadMapdata[" & strStockFileParent & "]" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CannotReadMapdata[" & strStockFileParent & "]" & strErrSig
    '                End If
    '                If parentMapclass.LotNo.ToUpper.IndexOf(strLotNo.ToUpper) < 0 And strLotNo.ToUpper.IndexOf(parentMapclass.LotNo.ToUpper) < 0 Then
    '                    clsErrorLog.addlogWT("Error:margeLot/LotNoMismatch[map:" & parentMapclass.LotNo & "]" & strErrSig, HEADER)
    '                    Return "Error:margeLot/LotNoMismatch[map:" & parentMapclass.LotNo & "]" & strErrSig
    '                End If

    '                copyFileToFile(strStockFileParent, strStockFileParent & ".bak")
    '                If Not System.IO.File.Exists(strStockFileParent & ".bak") Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CanNotCreateBakFile:" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CanNotCreateBakFile:" & strErrSig
    '                End If
    '                '       仮フォルダ(親)に展開
    '                If Not unzipFiles(strStockFileParent, strTempPathParent) Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CanNotCreateBakFile:" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CanNotCreateBakFile:" & strErrSig
    '                End If
    '                If System.IO.File.Exists(strStockFolderParent & "*.zip") Then
    '                    deleteFile(strStockFolderParent & "*.zip")
    '                    If System.IO.File.Exists(strStockFolderParent & "*.zip") Then
    '                        clsErrorLog.addlogWT("Error:margeLot/CanNotDeleteFile:" & strErrSig, HEADER)
    '                        Return "Error:margeLot/CanNotDeleteFile:" & strErrSig
    '                    End If
    '                End If
    '            End If
    '        Else
    '            clsErrorLog.addlogWT("Error:margeLot/CanNotFindZipFile:" & strErrSig, HEADER)
    '            Return "Error:margeLot/CanNotFindZipFile:" & strErrSig
    '        End If
    '        If System.IO.File.Exists(strStockFileChild) Then
    '            If System.IO.File.Exists(strStockFileChild & ".bak") Then
    '                deleteFile(strStockFileChild & ".bak")
    '                If System.IO.File.Exists(strStockFileChild & ".bak") Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CanNotDeleteFile:" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CanNotDeleteFile:" & strErrSig
    '                End If
    '            End If
    '            If System.IO.File.Exists(strStockFileChild) Then
    '                '       子Map読み込み
    '                childMapclass = clsMapDataValidateCheck.getMapdata(strStockFileChild)
    '                If childMapclass Is Nothing Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CannotReadMapdata[" & strStockFileChild & "]" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CannotReadMapdata[" & strStockFileChild & "]" & strErrSig
    '                End If
    '                If childMapclass.LotNo.ToUpper.IndexOf(strLotNo.ToUpper) < 0 And strLotNo.ToUpper.IndexOf(childMapclass.LotNo.ToUpper) < 0 Then
    '                    clsErrorLog.addlogWT("Error:margeLot/LotNoMismatch[map:" & childMapclass.LotNo & "]" & strErrSig, HEADER)
    '                    Return "Error:margeLot/LotNoMismatch[map:" & childMapclass.LotNo & "]" & strErrSig
    '                End If

    '                copyFileToFile(strStockFileChild, strStockFileChild & ".bak")
    '                If Not System.IO.File.Exists(strStockFileChild & ".bak") Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CanNotCreateBakFile:" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CanNotCreateBakFile:" & strErrSig
    '                End If
    '                '       仮フォルダ(子)に展開
    '                If Not unzipFiles(strStockFileChild, strTempPathChild) Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CanNotCreateBakFile:" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CanNotCreateBakFile:" & strErrSig
    '                End If
    '            End If
    '        Else
    '            clsErrorLog.addlogWT("Error:margeLot/CanNotFindZipFile:" & strErrSig, HEADER)
    '            Return "Error:margeLot/CanNotFindZipFile:" & strErrSig
    '        End If

    '        ans = clsWaHexConverter.WaferListMargeable( _
    '            clsWaHexConverter.BinToHex(parentMapclass.Waferlist), _
    '            clsWaHexConverter.BinToHex(childMapclass.Waferlist))
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:margeLot/WaferListMismatch:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:margeLot/WaferListMismatch:" & ans & ":" & strErrSig
    '        End If

    '        For iWa As Integer = 1 To 25
    '            If childMapclass.Waferlist.Substring(iWa - 1, 1) = "1" Then
    '                '       W-NO-XX.DATを仮フォルダ(親）に移動
    '                Dim strWNofile As String = "W-NO-" & Format(iWa, "00") & ".DAT"
    '                copyFileToDir(strTempPathChild & "\" & strWNofile, strTempPathParent)
    '                If Not System.IO.File.Exists(strTempPathParent & "\" & strWNofile) Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CanNotCopyWno(" & strWNofile & "):" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CanNotCopyWno(" & strWNofile & "):" & strErrSig
    '                End If
    '                deleteFile(strTempPathChild & "\" & strWNofile)
    '                If System.IO.Directory.Exists(strTempPathChild & "\" & strWNofile) Then
    '                    clsErrorLog.addlogWT("Error:margeLot/CanNotDeleteWno(" & strWNofile & "):" & strErrSig, HEADER)
    '                    Return "Error:margeLot/CanNotDeleteWno(" & strWNofile & "):" & strErrSig
    '                End If
    '            End If
    '        Next

    '        '       LOTDATのWaリスト、数量書換え(親)
    '        Dim intParentPassTotal As Integer = parentMapclass.PassTotal
    '        Dim intParentFailTotal As Integer = parentMapclass.FailTotal
    '        Dim intChildPassTotal As Integer = 0
    '        Dim intChildFailTotal As Integer = 0
    '        Dim intI As Integer
    '        For intI = 1 To 25
    '            If childMapclass.Waferlist.Substring(25 - intI, 1) = "1" Then
    '                intParentPassTotal += childMapclass.PassWA(25 - (intI - 1))
    '                intParentFailTotal += childMapclass.FailWA(25 - (intI - 1))
    '            End If
    '        Next

    '        Dim strMargeWaferListHEX As String = clsWaHexConverter.MargeWaferList( _
    '            clsWaHexConverter.BinToHex(parentMapclass.Waferlist), _
    '            clsWaHexConverter.BinToHex(childMapclass.Waferlist))

    '        ans = MapData.overwriteLotDatwithLotNo(strTempPathParent & "\LOT.DAT", strLotNo, _
    '            clsWaHexConverter.HexToBin(strMargeWaferListHEX), intParentPassTotal, intParentFailTotal)
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:margeLot/CanNotUpdateLotDat-Parent:" & strErrSig, HEADER)
    '            Return "Error:margeLot/CanNotUpdateLotDat-Parent:" & strErrSig
    '        End If

    '        '       仮フォルダ(親）へzipアップロード
    '        Dim strStockFolder As String = strStockFolderParent

    '        If Not System.IO.Directory.Exists(strStockFolder) Then createFolder(strStockFolder)

    '        If Not zipFiles(strTempPathParent, strStockFolder & "\" & strLotNo & ".zip") Then
    '            clsErrorLog.addlogWT("Error:margeLot/CanNotUploadZipFileParent:" & strErrSig, HEADER)
    '            Return "Error:margeLot/CanNotUploadZipFileParent:" & strErrSig
    '        End If

    '        deleteFolderAll(strStockFolderChild)
    '        If System.IO.Directory.Exists(strStockFolderChild) Then
    '            clsErrorLog.addlogWT("Error:margeLot/CanNotDeleteStockFolderChild:" & strErrSig, HEADER)
    '            Return "Error:margeLot/CanNotDeleteStockFolderChild:" & strErrSig
    '        End If
    '        deleteFolderAll(strTempPathChild)
    '        If System.IO.Directory.Exists(strTempPathChild) Then
    '            clsErrorLog.addlogWT("Error:margeLot/CanNotDeleteChildTmpFolder:" & strErrSig, HEADER)
    '            Return "Error:margeLot/CanNotDeleteChildTmpFolder:" & strErrSig
    '        End If
    '        deleteFolderAll(strTempPathParent)
    '        If System.IO.Directory.Exists(strTempPathParent) Then
    '            clsErrorLog.addlogWT("Error:margeLot/CanNotDeleteParentTmpFolder:" & strErrSig, HEADER)
    '            Return "Error:margeLot/CanNotDeleteParentTmpFolder:" & strErrSig
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsNfdMap/MargeLot" & strErrSig, HEADER)
    '        Return "Error:" & ex.ToString
    '    End Try
    '    Return "True"
    'End Function

    'Const DELETELOOPMAX As Integer = 3
    'Private Shared Sub DirectoryDelete(ByVal strDir As String, ByVal IsDeleteSubfolder As Boolean)
    '    For i As Integer = 0 To DELETELOOPMAX
    '        Try
    '            System.IO.Directory.Delete(strDir, IsDeleteSubfolder)
    '            Exit Sub
    '        Catch ex As Exception
    '            System.Threading.Thread.Sleep(1000)
    '        End Try
    '    Next
    '    System.IO.Directory.Delete(strDir, IsDeleteSubfolder) '最後はエラートラップなしで実行し、それでも失敗したら例外を返せるようにする
    'End Sub

    'テンポラリＭＡＰパス
    Public Shared Function Temp_mappath_root() As String
        Dim temp_folder As String = System.IO.Directory.GetCurrentDirectory & "\MAP"
        If Not System.IO.Directory.Exists(temp_folder) Then
            createFolder(temp_folder)
        End If
        Return temp_folder
    End Function

    'バックアップパス
    Public Shared Function Nfd_backup_root() As String
        Return System.Configuration.ConfigurationManager.AppSettings("BACKUP_PATH")
    End Function

    'NFD用パス
    Public Shared Function Nfd_mappath_root(ByVal strPath As String) As String
        Return System.Configuration.ConfigurationManager.AppSettings(strPath)
    End Function

    'テンポラリパス
    Public Shared Function Temp_path_root() As String
        Return System.IO.Directory.GetCurrentDirectory & "\FSTRAN"
    End Function

    'Marge用パス
    Public Shared Function Temp_Marge_root() As String
        Return System.IO.Directory.GetCurrentDirectory & "\MARGE"
    End Function

    'Input用パス
    Public Shared Function Temp_Input_root() As String
        Return System.IO.Directory.GetCurrentDirectory & "\Input"
    End Function

    'Strip用パス
    Public Shared Function Strip_root() As String
        Return System.IO.Directory.GetCurrentDirectory & "\Strip"
    End Function

    'Strip_Temp用パス
    Public Shared Function Temp_Strip_root() As String
        Return System.IO.Directory.GetCurrentDirectory & "\Strip_Temp"
    End Function


    Private Sub myFileGet(ByRef bytContents As Byte(), ByRef strVarInput As String, ByVal intAddress As Integer)
        Dim bytPartial(strVarInput.Length - 1) As Byte
        Array.Copy(bytContents, intAddress - 1, bytPartial, 0, bytPartial.Length)
        strVarInput = System.Text.Encoding.GetEncoding("shift-jis").GetString(bytPartial)
    End Sub
End Class
