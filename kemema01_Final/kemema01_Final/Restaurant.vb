Option Strict On
Option Explicit On

Imports kemema01_Final

Public Class Restaurant
    Implements IComparable(Of Restaurant)

    Private mID As Integer
    Private mName As String
    Private mTags As List(Of Tag)
    Private mCost As Integer
    Private mDineIn As Boolean
    Private mCarryOut As Boolean
    Private mDelivery As Boolean

    Public Property Name As String
        Get
            Return mName
        End Get
        Set(value As String)
            mName = value
        End Set
    End Property

    Public Property ID As Integer
        Get
            Return mID
        End Get
        Set(value As Integer)
            mID = value
        End Set
    End Property

    Public Property Cost As Integer
        Get
            Return mCost
        End Get
        Set(value As Integer)
            mCost = value
        End Set
    End Property

    Public Sub New(pID As Integer, pName As String, pTags As List(Of Tag), pCost As Integer, pDineIn As Boolean,
                   pCarryOut As Boolean, pDelivery As Boolean, pCats As List(Of Category))
        mID = pID
        mName = pName
        mCost = pCost
        CopyTags(pTags)
        'CopyCats(pCats)
    End Sub

    Public Function GetTags() As List(Of Tag)
        Dim output As New List(Of Tag)

        For Each tag In mTags
            Dim temp As New Tag(tag.ID, tag.TagValue)
            output.Add(temp)
        Next

        Return output
    End Function

    Public Sub CopyTags(pTags As List(Of Tag))
        Dim tmpTag As Tag

        For Each tag In pTags
            tmpTag = New Tag(tag.ID, tag.TagValue)
            mTags.Add(tmpTag)
            tmpTag = Nothing
        Next
    End Sub

    'Public Sub CopyCats(pCats As List(Of Category))
    '    Dim tmpCat As Category

    '    For Each cat In pCats
    '        tmpCat = New Category(cat.ID, cat.CatValue)
    '        mCategories.Add(tmpCat)
    '        tmpCat = Nothing
    '    Next
    'End Sub

    Public Function CompareTo(other As Restaurant) As Integer Implements IComparable(Of Restaurant).CompareTo
        Dim result As Integer = Me.mID.CompareTo(other.mID)
        If result = 0 Then
            result = Me.Name.CompareTo(other.Name)
        End If

        Return result
    End Function
End Class
