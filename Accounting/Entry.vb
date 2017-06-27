Imports Accounting

Public Class Entry
    Private v1 As Integer
    Private v2 As Integer
    Private 資産 As AccountBase

    Public Sub New(資産 As AccountBase, v1 As Integer, v2 As Integer)
        Me.資産 = 資産
        Me.v1 = v1
        Me.v2 = v2
    End Sub

    Public Property Amount As Decimal
End Class
