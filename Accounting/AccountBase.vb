﻿Imports Accounting

Public Class AccountBase

    Private _Entrys As New List(Of Entry)

    Private _ChildAccounts As New List(Of DetailAccount)



    ''' <summary>
    ''' このインスタンスが保持する勘定科目を取得します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Accounts() As IEnumerable(Of DetailAccount)
        Get
            Return _ChildAccounts.ToList.AsEnumerable
        End Get
    End Property


    ''' <summary>
    ''' 勘定の残高を取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Balance As Decimal
        Get
            If _Entrys.Any Then
                Return _Entrys.Select(Function(e) e.Amount).Sum
            End If
            Return 0
        End Get
    End Property



    ''' <summary>
    ''' このインスタンスに新しい勘定科目を追加します。
    ''' </summary>
    ''' <param name="AccountCode"></param>
    ''' <param name="AccountName"></param>
    ''' <remarks></remarks>
    Public Sub Add(ByVal AccountCode As Integer, ByVal AccountName As String)
        Dim NewAccount As New DetailAccount(Me, AccountCode, AccountName)
    End Sub


    ''' <summary>
    ''' 指定された明細勘定をこのインスタンスに追加します。
    ''' </summary>
    ''' <param name="NewAccount"></param>
    ''' <remarks>明細勘定から呼び出されることを想定したメソッドです。</remarks>
    Friend Sub Add(ByVal NewAccount As DetailAccount)
        _ChildAccounts.Add(NewAccount)
    End Sub


End Class