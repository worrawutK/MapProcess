Public Class Mode
    Public Event CheckedChange()
    Private _Select As String
    Public ReadOnly Property Mode() As String
        Get
            If rbtA.Checked Then
                _Select = "A"
            ElseIf rbtB.Checked Then

                _Select = "B"
            ElseIf rbtC.Checked Then

                _Select = "C"
            Else
                _Select = Nothing
            End If

            Return _Select
        End Get
      
    End Property

  


    Private Sub rbtA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtA.CheckedChanged, rbtB.CheckedChanged _
    , rbtC.CheckedChanged, Me.Click

        RaiseEvent CheckedChange()
        Dispose()
    End Sub
End Class
