Imports System
Imports System.Windows.Forms

Public Class MTech010VerticalProgressbar
    Inherits ProgressBar

    Protected Overloads Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim Cp As CreateParams = MyBase.CreateParams
            Cp.Style = Cp.Style Or &H4

            Return Cp
        End Get
    End Property
End Class