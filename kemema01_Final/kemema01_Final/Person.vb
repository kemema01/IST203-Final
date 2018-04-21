Option Strict On
Option Explicit On

Public Class Person
    Implements IComparable(Of Person)

    Private mID As Integer
    Private mName As String
    Private mLikes As List(Of Tag)
    Private mDislikes As List(Of Tag)

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

    Public Property Likes As List(Of Tag)
        Get
            Dim temp As Tag
            Dim tempList As New List(Of Tag)
            For Each descriptor In mLikes
                temp = New Tag(descriptor)
                tempList.Add(temp)
                temp = Nothing
            Next
            Return tempList
        End Get
        Set(value As List(Of Tag))
            mLikes.Clear()
            Dim temp As Tag
            For Each descriptor In value
                temp = New Tag(descriptor)
                mLikes.Add(temp)
                temp = Nothing
            Next
        End Set
    End Property

    Public Property Dislikes As List(Of Tag)
        Get
            Dim temp As Tag
            Dim tempList As New List(Of Tag)
            For Each descriptor In mDislikes
                temp = New Tag(descriptor)
                tempList.Add(temp)
                temp = Nothing
            Next
            Return tempList
        End Get
        Set(value As List(Of Tag))
            mDislikes.Clear()
            Dim temp As Tag
            For Each descriptor In value
                temp = New Tag(descriptor)
                mDislikes.Add(temp)
                temp = Nothing
            Next
        End Set
    End Property

    Public Sub New(pID As Integer, pName As String)
        mID = pID
        mName = pName
        mLikes = New List(Of Tag)
        mDislikes = New List(Of Tag)
    End Sub

    Public Sub New(pPerson As Person)
        mID = pPerson.ID
        mName = pPerson.Name
        mLikes = New List(Of Tag)
        mDislikes = New List(Of Tag)
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

    Public Function CompareTo(other As Person) As Integer Implements IComparable(Of Person).CompareTo
        Dim result As Integer = Me.ID.CompareTo(other.ID)
        If result = 0 Then
            result = Me.Name.CompareTo(other.Name)
        End If

        Return result
    End Function

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
