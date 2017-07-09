Namespace Account
    Public Class Liabilities
        Inherits Base

        Friend Overrides Function GetTransactionsBalanceCalculator() As Func(Of Decimal, Decimal)
            Return (Function(D) -D)
        End Function
    End Class
End Namespace