Public Class IVA

    Public Sub New()

    End Sub

    Public Sub New(ByVal Id As Integer, ByVal desc As String, ByVal Multip As Double)
        pId = Id
        pDescripcion = desc
        pMultiplicador = Multip
    End Sub

    Private pId As Integer
    Public Property ID() As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
        End Set
    End Property

    Private pDescripcion As String
    Public Property Descripcion() As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property

    Private pMultiplicador As Double
    Public Property Multiplicador() As Double
        Get
            Return pMultiplicador
        End Get
        Set(ByVal value As Double)
            pMultiplicador = value
        End Set
    End Property

End Class
