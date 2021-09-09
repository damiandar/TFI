
Public Class FacturaVenta
    Inherits Comprobante

    Public Enum eLetra
        A
        B
    End Enum

    Private pCliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return pCliente
        End Get
        Set(ByVal value As Cliente)
            pCliente = value
        End Set
    End Property

    Private pNro As Integer
    Public Property Nro As Integer
        Get
            Return pNro
        End Get
        Set(ByVal value As Integer)
            pNro = value
        End Set
    End Property

    Private pLetra As eLetra
    Public Property Letra() As eLetra
        Get
            Return pLetra
        End Get
        Set(ByVal value As eLetra)
            pLetra = value
        End Set
    End Property

    Private pPtoVenta As Integer
    Public Property PtoVenta() As Integer
        Get
            Return pPtoVenta
        End Get
        Set(ByVal value As Integer)
            pPtoVenta = value
        End Set
    End Property

    Private pCAE As String
    Public Property CAE() As String
        Get
            Return pCAE
        End Get
        Set(ByVal value As String)
            pCAE = value
        End Set
    End Property

    Private pCAI As String
    Public Property CAI() As String
        Get
            Return pCAI
        End Get
        Set(ByVal value As String)
            pCAI = value
        End Set
    End Property

    Private pItems As List(Of FacturaVentaItem)
    Public Property Items() As List(Of FacturaVentaItem)
        Get
            Return pItems
        End Get
        Set(ByVal value As List(Of FacturaVentaItem))
            pItems = value
        End Set
    End Property

    Private pPedidoID As Integer
    Public Property PedidoID() As Integer
        Get
            Return pPedidoID
        End Get
        Set(ByVal value As Integer)
            pPedidoID = value
        End Set
    End Property


    Public ReadOnly Property Total() As Double
        Get
            Dim UnTotal As Double = 0
            If Me.Items IsNot Nothing Then
                UnTotal = Me.Items.Sum(Function(x) x.Total)
            End If
            Return UnTotal
        End Get
    End Property

End Class
