Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class AccountTest

    <TestMethod()> Public Sub 勘定科目追加テスト()
        Dim 資産 As New Asset
        資産.Add(1, "現金")
        Assert.AreEqual(資産.Accounts.Count, 1)
        Assert.AreEqual(資産.Accounts.First.Title, "現金")
        Assert.AreEqual(資産.Accounts.First.Code, 1)
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(ArgumentException))>
    Public Sub 勘定科目重複テスト()
        Dim 資産 As New Asset
        資産.Add(1, "現金")
        資産.Add(1, "現金")
        Assert.Fail("勘定科目重複例外が発生しなければなりません。")
    End Sub

End Class