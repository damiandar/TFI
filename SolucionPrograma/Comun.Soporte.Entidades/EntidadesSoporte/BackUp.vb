Public Class BackUp

    Private pId As Integer
    Public Property ID() As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
        End Set
    End Property

    Private pRuta As String
    Public Property Ruta() As String
        Get
            Return pRuta
        End Get
        Set(ByVal value As String)
            pRuta = value
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



    Private pFecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return pFecha
        End Get
        Set(ByVal value As DateTime)
            pFecha = value
        End Set
    End Property

End Class
