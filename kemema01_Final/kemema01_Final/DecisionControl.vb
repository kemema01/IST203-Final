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
    Private Shared mCategoriesGood As Boolean() = {False, False, False} 'index 0=dine in, 1=carryout, 2=delivery
    Private Shared mCategoriesBad As Boolean() = {False, False, False} 'ditto
    Private Shared candidates As New List(Of Restaurant)
    Private Shared bigList As New List(Of Restaurant)
    Private Shared mWinner As Restaurant
    Private Shared mScoreBoard As New List(Of Restaurant)
    Private Shared mFinalFlag As Boolean = False
    'Private shared mSplashStatus As string


    Private Sub New()

    End Sub

    'reset decisioncontrol
    Public Shared Sub Reset()
        Progress = 0
        PeopleMasterList.Clear()
        PeoplePresentList.Clear()
        TagMasterList.Clear()
        TagWantedList.Clear()
        RestMasterList.Clear()
        RestSoundsBad.Clear()
        TagsSoundsBad.Clear()
        CatBad = {False, False, False}
        CatGood = {False, False, False}
        candidates.Clear()
        bigList.Clear()
        ScoreBoard.Clear()
        FinalFlag = False
        Winner = Nothing

    End Sub

    Public Shared Property Progress As Integer
        '0: Fresh run, nothing set.
        '1: Attendance form first load, populate master people list
        '2: Attendance form operation complete, people present list received
        '3: Sounds Good form first load, populate master tag list
        '4: Sounds good form operation complete, tag wanted list received
        '5: Sounds Bad form first load, lists loaded.
        '6: Sounds Bad lists received.
        '7: FinalForm loaded
        '8: Complete
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

    Public Shared Property TagMasterList As List(Of Tag)
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

    Public Shared Property CatGood As Boolean()
        Get
            Return mCategoriesGood
        End Get
        Set(value As Boolean())
            For i As Integer = 0 To 2 Step 1
                mCategoriesGood(i) = value(i)
            Next
        End Set
    End Property

    Public Shared Property CatBad As Boolean()
        Get
            Return mCategoriesBad
        End Get
        Set(value As Boolean())
            For i As Integer = 0 To 2 Step 1
                mCategoriesBad(i) = value(i)
            Next
        End Set
    End Property

    Public Shared Property Winner As Restaurant
        Get
            Return mWinner
        End Get
        Set(value As Restaurant)
            mWinner = value
        End Set
    End Property

    Public Shared Property ScoreBoard As List(Of Restaurant)
        Get
            Return mScoreBoard
        End Get
        Set(value As List(Of Restaurant))
            mScoreBoard = value
        End Set
    End Property

    Public Shared Property FinalFlag As Boolean
        Get
            Return mFinalFlag
        End Get
        Set(value As Boolean)
            mFinalFlag = value
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

    Public Shared Sub LoadPrefs()
        'Load likes/dislikes
        For Each buddy In DecisionControl.PeoplePresentList
            DBUtilities.GetLikeLines(buddy)
            DBUtilities.GetDislikeLines(buddy)
        Next
    End Sub

    Public Shared Sub LoadCandidates()
        'Load a list for final decision making
        For Each restaurant In DecisionControl.RestMasterList
            candidates.Add(restaurant)
        Next
    End Sub

    Public Shared Sub FilterCandidates()
        'Remove those that sound bad
        For Each rest In DecisionControl.RestSoundsBad
            If candidates.Contains(rest) Then
                candidates.Remove(rest)
            End If
        Next
        Dim temp As New List(Of Restaurant)
        For Each rest In candidates
            temp.Add(rest)
        Next
        For Each rest In candidates
            'If DecisionControl.RestSoundsBad.Contains(rest) Then
            '    candidates.Remove(rest)
            'End If
            'index 0=dine in, 1=carryout, 2=delivery
            If DecisionControl.CatBad(0) = True And rest.DineIn = True Then
                If Not (rest.CarryOut = True Or rest.Delivery = True) Then
                    If temp.Contains(rest) Then
                        temp.Remove(rest)
                    End If

                End If
            End If
            If DecisionControl.CatBad(1) = True And rest.CarryOut = True Then
                If Not (rest.DineIn = True Or rest.Delivery = True) Then
                    If temp.Contains(rest) Then
                        temp.Remove(rest)
                    End If

                End If
            End If
            If DecisionControl.CatBad(2) = True And rest.Delivery = True Then
                If Not (rest.DineIn = True Or rest.CarryOut = True) Then
                    candidates.Remove(rest)
                    If temp.Contains(rest) Then
                        temp.Remove(rest)
                    End If
                End If
            End If
        Next
        candidates.Clear()
        For Each rest In temp
            candidates.Add(rest)
        Next
    End Sub

    Public Shared Sub ProcessScores()
        'determine score increases - exits to try to help balance score influence of many tags
        For Each restaurant In candidates
            For Each person In DecisionControl.PeoplePresentList
                For Each item In person.Likes
                    If restaurant.GetTags.Contains(item) Then
                        restaurant.Score += 2
                        Exit For
                    End If
                Next
            Next
            For Each item In DecisionControl.TagWantedList
                If restaurant.GetTags.Contains(item) Then
                    restaurant.Score += 1
                    Exit For
                End If
            Next
            'index 0=dine in, 1=carryout, 2=delivery
            If DecisionControl.CatGood(0) = True And restaurant.DineIn = True Then
                restaurant.Score += 1
            End If
            If DecisionControl.CatGood(1) = True And restaurant.CarryOut = True Then
                restaurant.Score += 1
            End If
            If DecisionControl.CatGood(2) = True And restaurant.Delivery = True Then
                restaurant.Score += 1
            End If
        Next

        'determine score penalties - exits to help balance score influence as above
        For Each restaurant In candidates
            For Each person In DecisionControl.PeoplePresentList
                If person.Dislikes.Count = 0 Then
                    Exit For
                Else
                    For Each item In person.Dislikes
                        If restaurant.GetTags.Contains(item) Then
                            restaurant.Score -= 3
                            Exit For
                        End If
                    Next
                End If
            Next
            For Each item In DecisionControl.TagsSoundsBad
                If restaurant.GetTags.Contains(item) Then
                    restaurant.Score -= 4
                    Exit For
                End If
            Next
        Next
    End Sub

    Public Shared Sub WeightList()
        'create "weighted" list of restaurants

        For Each rest In candidates
            If rest.Score > 0 Then
                For i As Integer = 1 To rest.Score Step 1
                    bigList.Add(rest)
                Next
            End If
        Next
    End Sub

    Public Shared Sub Selection()
        'randomly select the winner
        Dim randal As New Random
        Dim indexWinner As Integer = randal.Next(0, bigList.Count - 1)
        DecisionControl.Winner = New Restaurant(bigList(indexWinner))

    End Sub

    Public Shared Sub RunnersUp()
        'create top 5 list of restaurants according to score
        Dim shortList As New List(Of Restaurant)
        Dim max As Integer = -1
        Dim indexList As Integer = -1
        Dim listCap As Integer = 5

        If candidates.Count < listCap Then
            listCap = candidates.Count
        End If
        For i As Integer = 1 To 5 Step 1
            max = -1
            indexList = -1
            For Each rest In candidates
                If rest.Score > max Then
                    max = rest.Score
                    indexList = candidates.IndexOf(rest)
                End If
            Next
            Dim ph As New Restaurant(candidates(indexList))
            DecisionControl.ScoreBoard.Add(ph)
            candidates.RemoveAt(indexList)
        Next
    End Sub
End Class
