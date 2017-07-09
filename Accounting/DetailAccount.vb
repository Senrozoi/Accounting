Imports Accounting

Public Class DetailAccount
    Private _Owner As AccountBase
    Private _Code As Integer
    Private _Title As String

    Public Sub New(Owner As AccountBase, Code As Integer, Title As String)
        If Owner.Accounts.Where(Function(A) A._Code = Code).Any Then
            Throw New ArgumentException("既に使用されている勘定科目ｺｰﾄﾞです。")
        End If
        Me._Owner = Owner
        Me._Code = Code
        Me._Title = Title
        '科目側から要約勘定への登録を呼び出すことで相互関連を保証する。
        _Owner.Add(Me)
    End Sub

    ''' <summary>
    ''' このインスタンスの勘定科目ｺｰﾄﾞを取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Code As Integer
        Get
            Return _Code
        End Get
    End Property


    ''' <summary>
    ''' このインスタンスの勘定科目名を取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Title As String
        Get
            Return _Title
        End Get
    End Property

    ''' <summary>
    ''' この勘定科目に転記するための仕訳オブジェクトを生成します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EntryFactry(Amount As Decimal) As Entry
        Return New Entry(Me, Amount)
    End Function

    ''' <summary>
    ''' 勘定科目が生成する、貸借計算用の式を返します。
    ''' </summary>
    ''' <returns>仕訳オブジェクトが貸方に来る場合は引数をそのまま、借方の場合は引数の正負を逆にする関数Func(Of Decimal, Decimal)を返す</returns>
    Friend Function GetTransactionsBalanceCalculator() As Func(Of Decimal, Decimal)
        Return _Owner.GetTransactionsBalanceCalculator
    End Function

    ''' <summary>
    ''' この勘定科目に仕訳を転記します。
    ''' </summary>
    ''' <param name="Entry"></param>
    Friend Sub Post(Entry As Entry)
        _Owner.Post(Entry)
    End Sub
End Class
