Public Class Dataitem5
    Private _ID As String
    Private _Value As String
    Public Sub New(ByVal id As String, ByVal Value As String)
        _ID = id
        _Value = Value
    End Sub
    Public ReadOnly Property Get_Id() As String
        Get
            Return _ID
        End Get
    End Property
    Public ReadOnly Property Get_Value() As String
        Get
            Return _Value
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return _Value
        Return _ID
    End Function
End Class
