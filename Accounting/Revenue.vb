Public Class Revenue
    Inherits AccountBase

    Friend Overrides Function GetTransactionsBalanceCalculator() As Func(Of Decimal, Decimal)
        Return (Function(D) -D)
    End Function
End Class
