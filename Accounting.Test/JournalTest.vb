Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class JournalTest

    <TestMethod()> Public Sub 取引を記帳する()

        Dim 資産 As New Account.Asset
        資産.Add(1, "現金")

        Dim 資本 As New Account.Equity
        資本.Add(1, "出資金")

        Dim 出資金 As Entry = 資本.Accounts.Where(Function(A) A.Code = 1).Single.EntryFactry(10000)
        Dim 現金 As Entry = 資産.Accounts.Where(Function(A) A.Code = 1).Single.EntryFactry(10000)
        Dim Entrys As New List(Of Entry)
        Entrys.Add(出資金)
        Entrys.Add(現金)
        Dim 現金出資取引 As New Transaction(Entrys, Now, "現金で出資を受けた。")

        Dim 仕訳帳 As New Journal
        仕訳帳.Post(現金出資取引)

        Assert.AreEqual(資産.Balance, CDec(10000))
        Assert.AreEqual(資本.Balance, CDec(10000))
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(System.ArgumentException))>
    Public Sub 重複取引を記帳する()


        Dim 資産 As New Account.Asset
        資産.Add(1, "現金")

        Dim 収益 As New Account.Revenue
        収益.Add(1, "販売益")


        Dim 商品販売仕訳リスト As New List(Of Entry)
        商品販売仕訳リスト.Add(収益.Accounts.Where(Function(A) A.Code = 1).Single.EntryFactry(800))
        商品販売仕訳リスト.Add(資産.Accounts.Where(Function(A) A.Code = 1).Single.EntryFactry(800))
        Dim 商品販売取引 As New Transaction(商品販売仕訳リスト, Now, "商品を現金払いで販売した")


        Dim 仕訳帳 As New Journal
        仕訳帳.Post(商品販売取引)
        仕訳帳.Post(商品販売取引)

        Assert.Fail("重複取引記帳不能例外が発生しなければなりません。")
    End Sub

End Class