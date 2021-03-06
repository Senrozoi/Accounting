﻿Imports Accounting

Public Class Entry



    Private _PostAccount As AccountItem
    Private _Amount As Decimal


    Private _BalanceCalculator As Func(Of Decimal, Decimal)

    Public Sub New(PostAccount As AccountItem, Amount As Integer)
        Me._PostAccount = PostAccount
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
