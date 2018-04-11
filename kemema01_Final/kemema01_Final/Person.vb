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

    Public ReadOnly Property ID As Integer
        Get
            Return mID
        End Get
    End Property

    Public Sub New(pID As Integer, pName As String)
        mID = pID
        mName = pName

    End Sub

    Public Sub New(pPerson As Person)
        mID = pPerson.ID
        mName = pPerson.Name
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
        Return Me.Name.CompareTo(other.Name)
    End Function

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
