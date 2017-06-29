Public Class Transaction
    Private _Entrys As IEnumerable(Of Entry)
    Private _EstablishedDate As Date
    Private _Explanation As String


    Public Sub New(Entrys As IEnumerable(Of Entry),
                   EstablishedDate As Date,
                   Explanation As String)
        If Entrys.Count < 2 Then
            Throw New ArgumentException("エントリーは2つ以上必要です。")
        End If
        If Not MatchTheBalance(Entrys) Then
            Throw New ArgumentException("貸借が一致しません。")
        End If

        Me._Entrys = Entrys
        Me._EstablishedDate = EstablishedDate
        Me._Explanation = Explanation
    End Sub


    ''' <summary>
    ''' このインスタンスの摘要を取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Explanation As String
        Get
            Return _Explanation
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
            '保持エントリの内、正の数の金額を合計することで取扱金額が算出できる。
            Dim sum As Decimal = 0
            For Each Entry In _Entrys.Where(Function(e) e.TransactionBalanceAmount > 0)
                sum += Entry.TransactionBalanceAmount
            Next
            Return sum
        End Get
    End Property

    ''' <summary>
    ''' このインスタンスに含まれる仕訳を取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Entrys As IEnumerable(Of Entry)
        Get
            Return _Entrys
        End Get
    End Property

    ''' <summary>
    ''' このインスタンスが保持するエントリーの貸借が一致することを確認します。
    ''' </summary>
    ''' <param name="Entrys"></param>
    ''' <returns>一致する場合True、一致しない場合False</returns>
    ''' <remarks></remarks>
    Private Function MatchTheBalance(ByVal Entrys As IEnumerable(Of Entry)) As Boolean
        Dim Balance As Decimal = 0
        For Each Entry In Entrys
            Balance += Entry.TransactionBalanceAmount
        Next
        Return If(Balance = 0, True, False)
    End Function

End Class
