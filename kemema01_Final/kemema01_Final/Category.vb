Public Class Category
    Private mID As Integer
    Private mCatValue As String

    Public Sub New(pID As Integer, pCatValue As String)
        mID = pID
        mCatValue = pCatValue
    End Sub

    Public ReadOnly Property ID As Integer
        Get
            Return mID
        End Get
    End Property

    Public ReadOnly Property CatValue As String
        Get
            Return mCatValue
        End Get
    End Property
End Class
