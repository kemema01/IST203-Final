Option Strict On
Option Explicit On

Imports kemema01_Final

Public Class Tag
    Implements IComparable(Of Tag)

    Private mID As Integer
    Private mTagValue As String

    Public ReadOnly Property ID As Integer
        Get
            Return mID
        End Get
    End Property

    Public ReadOnly Property TagValue As String
        Get
            Return mTagValue
        End Get
    End Property

    Public Sub New(pID As Integer, pTagValue As String)
        mID = pID
        mTagValue = pTagValue
    End Sub

    Public Sub New(other As Tag)
        mID = other.ID
        mTagValue = other.TagValue
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim result As Boolean = False
        If TypeOf obj Is Tag Then
            Dim cast As Tag = CType(obj, Tag)
            If cast.TagValue.ToLower.Equals(Me.TagValue.ToLower) Then
                result = True
            End If
        End If
        Return result
    End Function

    Public Overrides Function ToString() As String
        Return TagValue
    End Function

    Public Function CompareTo(other As Tag) As Integer Implements IComparable(Of Tag).CompareTo
        Dim result As Integer = Me.ID.CompareTo(other.ID)
        If result = 0 Then
            result = Me.TagValue.CompareTo(other.TagValue)
        End If

        Return result
    End Function
End Class
