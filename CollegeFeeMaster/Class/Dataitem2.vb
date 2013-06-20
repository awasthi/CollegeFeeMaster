Public Class Dataitem2
    Private _ID As Integer
    Private _Value As String
    Private _Value2 As String

    Public Sub New(ByVal id As Integer, ByVal Value As String, ByVal Value2 As String)
        _ID = id
        _Value = Value
        _Value2 = Value2

    End Sub
    Public ReadOnly Property Get_Id() As Integer
        Get
            Return _ID
        End Get
    End Property
    Public ReadOnly Property Get_Value() As String
        Get
            Return _Value
        End Get
    End Property

    Public ReadOnly Property Get_Value2() As String
        Get
            Return _Value2
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return _Value
        Return _Value2
    End Function
End Class
