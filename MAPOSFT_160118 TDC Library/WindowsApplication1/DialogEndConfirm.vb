Public Class DialogEndConfirm
    Private c_EndLot As Status
    Public Property EndLot() As Status
        Get
            Return c_EndLot
        End Get
        Set(ByVal value As Status)
            c_EndLot = value
        End Set
    End Property
    Enum Status
        EndRetest
        EndNomal
    End Enum
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If LabelText.ForeColor = Color.Black Then
            LabelText.ForeColor = Color.Orange
        Else
            LabelText.ForeColor = Color.Black
        End If

    End Sub

    Private Sub ButtonEndRetest_Click(sender As Object, e As EventArgs) Handles ButtonEndRetest.Click
        EndLot = Status.EndRetest
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub ButtonEndNomal_Click(sender As Object, e As EventArgs) Handles ButtonEndNomal.Click
        EndLot = Status.EndNomal
        Me.DialogResult = DialogResult.OK
    End Sub
End Class