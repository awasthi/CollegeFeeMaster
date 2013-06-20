Public Class DataItem4
    Private _ID1 As Integer
    Private _Value1 As String
    Private _Value2 As String
    Private _ID2 As Integer
    Public Sub New(ByVal id1 As Integer, ByVal Value1 As String, ByVal Value2 As String, ByVal id2 As Integer)
        _ID1 = id1
        _ID2 = id2
        _Value1 = Value1
        _Value2 = Value2
    End Sub
    Public ReadOnly Property Get_Id1() As Integer
        Get
            Return _ID1
        End Get
    End Property
    Public ReadOnly Property Get_Id2() As Integer
        Get
            Return _ID2
        End Get
    End Property
    Public ReadOnly Property Get_Value1() As String
        Get
            Return _Value1
        End Get
    End Property
    Public ReadOnly Property Get_Value2() As String
        Get
            Return _Value2
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _Value1
        Return _Value2
    End Function
End Class
