
Public Class Servicio
    Inherits Catalogo

    Private pEventual As Boolean
    Public Property Eventual() As Boolean
        Get
            Return pEventual
        End Get
        Set(ByVal value As Boolean)
            pEventual = value
        End Set
    End Property

    Private pCondiciones As String
    Public Property Condiciones() As String
        Get
            Return pCondiciones
        End Get
        Set(ByVal value As String)
            pCondiciones = value
        End Set
    End Property

    Private pDuracion As Integer
    Public Property Duracion() As Integer
        Get
            Return pDuracion
        End Get
        Set(ByVal value As Integer)
            pDuracion = value
        End Set
    End Property


End Class
