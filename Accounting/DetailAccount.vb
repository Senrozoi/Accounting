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


    Public Function EntryFactry(v As Integer) As Entry
        Throw New NotImplementedException()
    End Function
End Class
