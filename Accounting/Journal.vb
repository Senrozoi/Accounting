Imports Accounting

Public Class Journal
    Private _Transactions As New List(Of Transaction)

    Public Sub Post(Transaction As Transaction)
        If _Transactions.Contains(Transaction) Then
            Throw New ArgumentException("記帳済の取引は記帳できません。")
        End If
        _Transactions.Add(Transaction)
        For Each Entry In Transaction.Entrys
            Entry.Post()
        Next
    End Sub
End Class
