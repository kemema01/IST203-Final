Option Strict On
Option Explicit On

Public NotInheritable Class DecisionControl
    'SHARED variables
    'Private, empty constructor
    '--Maybe. Probably not.
    Private Shared mPeopleMasterList As New List(Of Person)
    Private Shared mPeoplePresentList As New List(Of Person)
    Private Shared mTagMasterList As New List(Of Tag)
    Private Shared mTagWantedList As New List(Of Tag)
    Private Shared mRestMasterList As New List(Of Restaurant)
    Private Shared mRestSoundsBad As New List(Of Restaurant)
    Private Shared mTagsSoundsBad As New List(Of Tag)
    Private Shared mProgress As Integer


    Private Sub New()

    End Sub

    'reset decisioncontrol
    Public Shared Sub Reset()
        Progress = 0
        PeopleMasterList = New List(Of Person)
        PeoplePresentList = New List(Of Person)

    End Sub

    Public Shared Property Progress As Integer
        '0: Fresh run, nothing set.
        '1: Attendance form first load, populate master people list
        '2: Attendance form operation complete, people present list received
        '3: Sounds Good form first load, populate master tag list
        '4: Sounds good form operation complete, tag wanted list received
        '5: Sounds Bad form first load, lists loaded.
        '6: Sounds Bad lists received.
        Get
            Return mProgress
        End Get
        Set(value As Integer)
            mProgress = value
        End Set
    End Property

    Public Shared Property PeopleMasterList As List(Of Person) 'READ ONLY?
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

    Public Shared Property TagMasterList As List(Of Tag) 'READ ONLY?
        Get
            Return mTagMasterList
        End Get
        Set(value As List(Of Tag))
            mTagMasterList = value
        End Set
    End Property

    Public Shared Property RestMasterList As List(Of Restaurant)
        Get
            Return mRestMasterList
        End Get
        Set(value As List(Of Restaurant))
            mRestMasterList = value
        End Set
    End Property

    Public Shared Property TagWantedList As List(Of Tag)
        Get
            Return mTagWantedList
        End Get
        Set(value As List(Of Tag))
            mTagWantedList = value
        End Set
    End Property

    Public Shared Property RestSoundsBad As List(Of Restaurant)
        Get
            Return mRestSoundsBad
        End Get
        Set(value As List(Of Restaurant))
            mRestSoundsBad = value
        End Set
    End Property

    Public Shared Property TagsSoundsBad As List(Of Tag)
        Get
            Return mTagsSoundsBad
        End Get
        Set(value As List(Of Tag))
            mTagsSoundsBad = value
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
