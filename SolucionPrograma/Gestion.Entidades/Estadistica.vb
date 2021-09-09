Public Class Estadistica
    Public Sub New(ByVal id As Integer, ByVal desc As String, ByVal valor As Double)
        pID = id
        pDescripcion = desc
        pValor = valor
    End Sub

    Public Sub New()

    End Sub

    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
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

    Private pValor As Double
    Public Property Valor() As Double
        Get
            Return pValor
        End Get
        Set(ByVal value As Double)
            pValor = value
        End Set
    End Property
End Class
