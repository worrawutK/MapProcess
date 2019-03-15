Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim ringList As New Dictionary(Of String, String)
        ringList.Add("28Z-01311-05", "1910F4057V01")
        ringList.Add("28Z-01311-06", "1910F4057V02")
        ringList.Add("28Z-01311-07", "1910F4057V03")
        ringList.Add("28Z-01311-08", "1910F4057V04")
        MsgBox(ASE_MAPConvert(ringList, "1910F4057V", "A-01", "BU52272NUZ-ZA(X8G)", "VSON04Z111", Now, CDate("2017/06/01 20:00:00"))) 'BU52272NUZ-ZA(X8G),BU52272NUZ-Z(8A)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        CancelASEStrip("1910F4057V")

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim aa = MapDataInformGet("1910F4057V")
aa:
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim aa = ChkASEStripID("28Z-01311-08")
aa:
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim aa = ChkAssyLotNo("1910F4057V")
aa:
    End Sub

#Region "ASE MapConvert"

    Dim ZIP_TEMP_PATH As String = My.Application.Info.DirectoryPath & "\Zip_TEMP"
    Dim RECIPE_PATH As String = My.Application.Info.DirectoryPath & "\RECIPE"


    'Cancel before rerun ASE Ring
    Private Function CancelASEStrip(ByVal AssyLotNo As String) As String
        If Not AssyLotNo Like "*F*" Then
            Return "Error : Lot is not F Lot"
        End If
        Dim ans As String
        Using connect As New System.Data.SqlClient.SqlConnection
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing
            connect.ConnectionString = My.Settings.StripMapConnStr
            connect.Open()
            transact = connect.BeginTransaction
            Try
                ans = MapConvert.clsShareSub.CancelASEStrip(connect, transact, AssyLotNo)
                If ans Like "Error*" Then
                    transact.Rollback()
                    connect.Close()
                    Return ans & "_CancelASEStrip"
                End If
                transact.Commit()
                connect.Close()

            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try
        End Using

        Try
            'Delete All in ZipFile Path
            For Each deleteFile In IO.Directory.GetFiles(ZIP_TEMP_PATH, "*.*", IO.SearchOption.TopDirectoryOnly)
                IO.File.Delete(deleteFile)
            Next

        Catch ex As Exception

        End Try
     


        Return ans

    End Function


    ' RingID As Dictionary(ASE_RingID, Rohm_RingID)
    Private Function ASE_MAPConvert(ByVal RingID As Dictionary(Of String, String), ByVal AssyLotNo As String, McNo As String, ByVal Device As String, ByVal Package As String, ByVal AssyLotStartTime As Date, ByVal AssyLotEndTime As Date, Optional Remark As String = "") As String
        If Not AssyLotNo Like "*F*" Then
            Return "Error : Lot is not F Lot"
        End If
        Dim ans As String
        Using connect As New System.Data.SqlClient.SqlConnection           'tbl_stripMap table on stripMapdb
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing
            connect.ConnectionString = My.Settings.StripMapConnStr
            connect.Open()
            transact = connect.BeginTransaction
            Try
                For Each item In RingID
                    ans = MapConvert.clsShareSub.GetASEStripMapData(connect, transact, item.Key, AssyLotNo, item.Value)
                    If ans Like "Error*" Then
                        transact.Rollback()
                        connect.Close()
                        Return ans & "_GetASEStripMapData"
                    End If
                Next
                transact.Commit()
                connect.Close()
            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try

            ans = MapConvert.clsShareSub.XML_Marge(McNo, AssyLotNo, Device, Package, RingID.Count, RECIPE_PATH, ZIP_TEMP_PATH)
            If ans Like "Error*" Then
                Return ans & "_XML_Marge"
            End If
        End Using


        Using Dbxconnect As New System.Data.SqlClient.SqlConnection             'MapMapdata table on dbx
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing
            Dbxconnect.ConnectionString = My.Settings.DBxConnectionString
            Dbxconnect.Open()
            transact = Dbxconnect.BeginTransaction
            Try
                ans = MapConvert.clsShareSub.ASEStripInputLot(Dbxconnect, transact, McNo, AssyLotNo, "OS", "OS_NEW", ZIP_TEMP_PATH & "\" & AssyLotNo & ".zip", AssyLotStartTime, AssyLotEndTime, Remark)
                If ans Like "Error*" Then
                    transact.Rollback()
                    Dbxconnect.Close()
                    MsgBox("ASEStripInputLot :" & ans)
                    Return ans & "_ASEStripInputLot"
                End If
                transact.Commit()
                Dbxconnect.Close()
            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try

        End Using
        Return ans



    End Function

    Function ChkASEStripID(ByVal ASERingID As String)  'Cheeck AssyLotNo from tbl_StripMap

        Dim ans As String
        Using connect As New System.Data.SqlClient.SqlConnection
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing

            connect.ConnectionString = My.Settings.StripMapConnStr
            connect.Open()
            transact = connect.BeginTransaction
            Try
                ans = MapConvert.clsShareSub.ChkASEStripID(connect, transact, ASERingID)
                If ans Like "Error*" Then
                    If ans <> "Error: No Record Found" Then
                        transact.Rollback()
                        connect.Close()
                        Return ans
                    Else
                        transact.Rollback()
                        connect.Close()
                        Return "Error: No Data"
                    End If
                End If
                transact.Commit()
                connect.Close()

            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try
        End Using

        Return ans

    End Function

    Function ChkAssyLotNo(ByVal AssyLotNo As String) As String   'Cheeck AssyLotNo from tbl_StripMap
        If Not AssyLotNo Like "*F*" Then
            Return "Error : Lot is not F Lot"
        End If
        Dim ans As String
        Using connect As New System.Data.SqlClient.SqlConnection
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing

            connect.ConnectionString = My.Settings.StripMapConnStr
            connect.Open()
            transact = connect.BeginTransaction
            Try
                ans = MapConvert.clsShareSub.ChkAssyLotNo(connect, transact, AssyLotNo)
                If ans Like "Error*" Then
                    If ans <> "Error: No Record Found" Then
                        transact.Rollback()
                        connect.Close()
                        Return ans
                    Else
                        transact.Rollback()
                        connect.Close()
                        Return "Error: No Data"
                    End If
                End If
                transact.Commit()
                connect.Close()

            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try
        End Using
        Return ans
    End Function

    Function MapDataInformGet(ByVal AssyLotNo As String) As MapConvert.clsMapData

        Try
            Dim mapclass As MapConvert.clsMapData = MapConvert.clsMap.getMapData(ZIP_TEMP_PATH & "\" & AssyLotNo & ".zip")
            Return mapclass
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


#End Region


 
End Class
