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

    <TestMethod()>
    Public Sub 勘定科目不正追加テスト()
        Dim 資産 As New Asset
        資産.Add(1, "現金")
        '勘定のメソッドを通さずに勘定科目のインスタンスを作成
        Dim 不正勘定科目 As New DetailAccount(資産, 2, "貯金")

        '作成方法を問わず、整合性が維持できていることを確認する。
        Assert.AreEqual(資産.Accounts.Count, 2)
        Assert.AreEqual(資産.Balance, CDec(0))
    End Sub


    <TestMethod()>
    Public Sub 勘定科目不正操作不能確認テスト()
        Dim 負債 As New Liabilities
        負債.Add(1, "預り金")

        '要約勘定から取得した勘定科目リストを操作する。
        Dim 勘定科目列挙体 = 負債.Accounts
        Dim 勘定科目リスト = DirectCast(勘定科目列挙体, List(Of DetailAccount))
        '勘定から取得した勘定科目リストから要素を削除する。
        勘定科目リスト.Remove(勘定科目リスト.First())
        Assert.AreEqual(勘定科目リスト.Count, 0)

        '勘定から勘定科目が削除されていないことを確認する。
        Assert.AreEqual(負債.Accounts.Count, 1)

    End Sub

End Class