Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
<TestClass()> Public Class TransactionTest

    Private SetUpAsset As New Asset


    <TestInitialize()> Public Sub MyTestInitialize()
        SetUpAsset.Add(1, "現金")
    End Sub



    <TestMethod()> Public Sub 取引金額テスト()
        Dim 資産 As New Asset


        Dim 貸方 As New Entry(資産.GetItem(1), 10000)
        Dim 借方 As New Entry(資産.GetItem(1), -10000)

        Dim entrys As New List(Of Entry)
        entrys.Add(貸方)
        entrys.Add(借方)

        Dim 取引 As New Transaction(entrys, Now, "作成テスト")
        Assert.AreEqual(取引.Amount, CDec(10000))
    End Sub

    <TestMethod()> Public Sub 複数エントリ取引作成テスト()
        Dim 資産 As New Asset
        Dim 負債 As New Liabilities
        負債.Add(1, "借入金")
        Dim 費用 As New Expense
        費用.Add(1, "借入金利息")

        Dim 現金 As New Entry(資産.GetItem(1), -10000)
        Dim 借入 As New Entry(負債.GetItem(1), -9000)
        Dim 利息 As New Entry(費用.GetItem(1), 1000)

        Dim entrys As New List(Of Entry)
        entrys.Add(現金)
        entrys.Add(借入)
        entrys.Add(利息)

        Dim 取引 As New Transaction(entrys, Now, "借入金とその利息を現金で支払った")
        Assert.AreEqual(取引.Amount, CDec(10000))
    End Sub


    <TestMethod()>
    <ExpectedException(GetType(System.ArgumentException))>
    Public Sub 取引貸借不一致テスト()

        Dim 資産 As New Asset
        Dim 貸方 As New Entry(資産.GetItem(1), 10000)
        Dim 借方 As New Entry(資産.GetItem(1), -1000)

        Dim entrys As New List(Of Entry)
        entrys.Add(貸方)
        entrys.Add(借方)


        Dim 取引 As New Transaction(entrys, Now, "貸借不一致取引")
        Assert.Fail("貸借不一致例外が発生しなければなりません。")
    End Sub


    <TestMethod()>
    <ExpectedException(GetType(System.ArgumentException))>
    Public Sub 取引エントリ数不足テスト()

        Dim 資産 As New Asset
        Dim 貸方 As New Entry(資産.GetItem(1), 0)

        Dim entrys As New List(Of Entry)
        entrys.Add(貸方)

        Dim 取引 As New Transaction(entrys, Now, "エントリ数不足取引")
        Assert.Fail("エントリ数不足例外が発生しなければなりません。")
    End Sub


    <TestMethod()>
    <ExpectedException(GetType(System.ArgumentException))>
    Public Sub 未登録勘定科目使用テスト()

        Dim 資産 As New Asset
        資産.Add(1, "現金")

        Dim 貸方 As New Entry(資産.GetItem(1), -10)
        Dim 借方 As New Entry(資産.GetItem(1), 10)

        Dim entrys As New List(Of Entry)
        entrys.Add(貸方)
        entrys.Add(借方)

        Dim 取引 As New Transaction(entrys, Now, "未登録勘定科目使用取引")
        Assert.Fail("未登録勘定科目使用例外が発生しなければなりません。")
    End Sub

End Class