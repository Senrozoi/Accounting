Imports Accounting

Public Class Entry



    Private _PostAccount As AccountBase
    Private _AccountCode As Integer
    Private _Amount As Decimal


    Private _BalanceCalculator As Func(Of Decimal, Decimal)

    Public Sub New(PostAccount As AccountBase, AccountCode As Integer, Amount As Integer)
        Me._PostAccount = PostAccount
        Me._AccountCode = AccountCode
        Me._Amount = Amount
        Me._BalanceCalculator = PostAccount.GetTransactionsBalanceCalculator()

    End Sub

    ''' <summary>
    ''' 勘定に記帳します。
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub Post()
        _PostAccount.Post(Me)
    End Sub

    ''' <summary>
    ''' このインスタンスの科目ｺｰﾄﾞを取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AccountCode As Integer
        Get
            Return _AccountCode
        End Get
    End Property

    ''' <summary>
    ''' このインスタンスで取り扱う金額を取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Amount As Decimal
        Get
            Return _Amount
        End Get
    End Property


    ''' <summary>
    ''' このインスタンスの取引貸借一致計算用の金額を返します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TransactionBalanceAmount As Decimal
        Get
            Return _BalanceCalculator(_Amount)
        End Get
    End Property
End Class
