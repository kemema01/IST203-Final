Public Class Tag
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
End Class
