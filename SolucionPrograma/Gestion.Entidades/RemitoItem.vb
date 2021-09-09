
Public Class RemitoItem 

    Private pInsumo As Insumo
    Public Property insumo() As Insumo
        Get
            Return pInsumo
        End Get
        Set(ByVal value As Insumo)
            pInsumo = value
        End Set
    End Property

    Private pCantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return pCantidad
        End Get
        Set(ByVal value As Integer)
            pCantidad = value
        End Set
    End Property

End Class
