Public Class Restaurant
    Private mID As Integer
    Private mName As String
    Private mTags As List(Of Tag)

    Public Sub New(pID As Integer, pName As String, pTags As List(Of Tag))
        mID = pID
        mName = pName
        CopyTags(pTags)
    End Sub

    Public Sub CopyTags(pTags As List(Of Tag))
        Dim tmpTag As Tag

        For Each tag In pTags
            tmpTag = New Tag(tag.ID, tag.TagValue)
            mTags.Add(tmpTag)
            tmpTag = Nothing
        Next
    End Sub

End Class
