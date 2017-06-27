Public Class Transaction
    Public ReadOnly Amount As Decimal
    Private entrys As List(Of Entry)
    Private now As Date
    Private v As String

    Public Sub New(entrys As List(Of Entry), now As Date, v As String)
        Me.entrys = entrys
        Me.now = now
        Me.v = v
    End Sub
End Class
