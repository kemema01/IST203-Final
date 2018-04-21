Option Strict On
Option Explicit On

Imports kemema01_Final

Public Class Restaurant
    Implements IComparable(Of Restaurant)

    Private mID As Integer
    Private mName As String
    Private mTags As New List(Of Tag)
    Private mCost As Integer
    Private mDineIn As Boolean
    Private mCarryOut As Boolean
    Private mDelivery As Boolean
    Private mScore As Integer

    Public Property DineIn As Boolean
        Get
            Return mDineIn
        End Get
        Set(value As Boolean)
            mDineIn = value
        End Set
    End Property

    Public Property CarryOut As Boolean
        Get
            Return CarryOut
        End Get
        Set(value As Boolean)
            mCarryOut = value
        End Set
    End Property

    Public Property Delivery As Boolean
        Get
            Return mDelivery
        End Get
        Set(value As Boolean)
            mDelivery = value
        End Set
    End Property

    Public Property Score As Integer
        Get
            Return mScore
        End Get
        Set(value As Integer)
            mScore = value
        End Set
    End Property

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

    Public Sub New(pID As Integer, pName As String, pCost As Integer, pDineIn As Boolean,
                   pCarryOut As Boolean, pDelivery As Boolean)
        mID = pID
        mName = pName
        mCost = pCost
        mDineIn = pDineIn
        mCarryOut = pCarryOut
        mDelivery = pDelivery
        mScore = 1
    End Sub

    Public Sub New(pRest As Restaurant)
        mID = pRest.ID
        mName = pRest.Name
        mCost = pRest.Cost
        mDineIn = pRest.DineIn
        mCarryOut = pRest.CarryOut
        mDelivery = pRest.Delivery
        mScore = pRest.Score
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
    Public Overrides Function ToString() As String
        Return Name
    End Function

    Public Function ToStringScore() As String
        Return "(" + Score.ToString + ") " + Name
    End Function

    Public Function CompareTo(other As Restaurant) As Integer Implements IComparable(Of Restaurant).CompareTo
        Dim result As Integer = Me.ID.CompareTo(other.ID)
        If result = 0 Then
            result = Me.Name.CompareTo(other.Name)
        End If

        Return result
    End Function
End Class
