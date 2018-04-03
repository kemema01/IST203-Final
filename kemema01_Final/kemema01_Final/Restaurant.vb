Public Class Restaurant
    Private mID As Integer
    Private mName As String
    Private mTags As List(Of Tag)
    Private mCategories As List(Of Category)

    Public Sub New(pID As Integer, pName As String, pTags As List(Of Tag), pCats As List(Of Category))
        mID = pID
        mName = pName
        CopyTags(pTags)
        CopyCats(pCats)
    End Sub

    Public Sub CopyTags(pTags As List(Of Tag))
        Dim tmpTag As Tag

        For Each tag In pTags
            tmpTag = New Tag(tag.ID, tag.TagValue)
            mTags.Add(tmpTag)
            tmpTag = Nothing
        Next
    End Sub

    Public Sub CopyCats(pCats As List(Of Category))
        Dim tmpCat As Category

        For Each cat In pCats
            tmpCat = New Category(cat.ID, cat.CatValue)
            mCategories.Add(tmpCat)
            tmpCat = Nothing
        Next
    End Sub
End Class
