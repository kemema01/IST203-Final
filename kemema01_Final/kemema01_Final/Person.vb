Public Class Person
    Private mID As Integer
    Private mName As String
    Private mLikes As List(Of Tag)
    Private mDislikes As List(Of Tag)

    Public Sub New(pID As Integer, pName As String, pLikes As List(Of Tag), pDislikes As List(Of Tag))
        mID = pID
        mName = pName
        ImportLikes(pLikes)
        ImportDislikes(pDislikes)
    End Sub

    Public Sub ImportLikes(pTags As List(Of Tag))
        Dim tmpTag As Tag = Nothing

        For Each tag In pTags
            If mLikes.Contains(tag) = False Then
                tmpTag = New Tag(tag.ID, tag.TagValue)
                mLikes.Add(tmpTag)
            End If
            tmpTag = Nothing
        Next
    End Sub

    Public Sub ImportDislikes(pTags As List(Of Tag))
        Dim tmpTag As Tag

        For Each tag In pTags
            If mDislikes.Contains(tag) = False Then
                tmpTag = New Tag(tag.ID, tag.TagValue)
                mDislikes.Add(tmpTag)
            End If
            tmpTag = Nothing
        Next
    End Sub
End Class
