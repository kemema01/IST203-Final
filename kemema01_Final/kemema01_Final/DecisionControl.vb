Public NotInheritable Class DecisionControl
    'SHARED variables
    'Private, empty constructor
    '--Maybe. Probably not.
    Private Shared mPeopleMasterList As New List(Of Person)
    Private Shared mPeoplePresentList As New List(Of Person)
    Private Shared mProgress As Integer = 0

    Private Sub New()
        'Can't instantiate
    End Sub

    Public Shared Property Progress As Integer
        Get
            Return mProgress
        End Get
        Set(value As Integer)
            mProgress = value
        End Set
    End Property

    Public Shared Property PeopleMasterList As List(Of Person)
        Get
            Return mPeopleMasterList
        End Get
        Set(value As List(Of Person))
            mPeopleMasterList = value
        End Set
    End Property

    Public Shared Property PeoplePresentList As List(Of Person)
        Get
            Return mPeoplePresentList
        End Get
        Set(value As List(Of Person))
            mPeoplePresentList = value
        End Set
    End Property

    'Who's Here?
    'Receive list of people present from AttendanceForm

    'What Sounds Good?
    'Receive list of weighted tags

    'Decision Processing
    'generate megalist of restaurants according to tags, select randomly

    'Decision Confirmation
    'report decision
    'present highest weights
    'update history
End Class
