
Public Class Stock

    Private pMinimo As Integer
    Public Property Minimo() As Integer
        Get
            Return pMinimo
        End Get
        Set(ByVal value As Integer)
            pMinimo = value
        End Set
    End Property

    Private pMaximo As Integer
    Public Property Maximo() As Integer
        Get
            Return pMaximo
        End Get
        Set(ByVal value As Integer)
            pMaximo = value
        End Set
    End Property

    Private pActual As Integer
    Public Property Actual() As Integer
        Get
            Return pActual
        End Get
        Set(ByVal value As Integer)
            pActual = value
        End Set
    End Property

    Private pUltimoMovimiento As DateTime
    Public Property UltimoMovimiento() As DateTime
        Get
            Return pUltimoMovimiento
        End Get
        Set(ByVal value As DateTime)
            pUltimoMovimiento = value
        End Set
    End Property

End Class
