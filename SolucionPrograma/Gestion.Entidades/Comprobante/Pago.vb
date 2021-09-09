
Public Class Pago
    Inherits Comprobante

    Private pCliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return pCliente
        End Get
        Set(ByVal value As Cliente)
            pCliente = value
        End Set
    End Property


    Private pFechaPago As Date
    Public Property FechaPago() As Date
        Get
            Return pFechaPago
        End Get
        Set(ByVal value As Date)
            pFechaPago = value
        End Set
    End Property

    Private pFormaPago As FormaPago
    Public Property formapago() As FormaPago
        Get
            Return pFormaPago
        End Get
        Set(ByVal value As FormaPago)
            pFormaPago = value
        End Set
    End Property

    Private pConcepto As String
    Public Property Concepto() As String
        Get
            Return pConcepto
        End Get
        Set(ByVal value As String)
            pConcepto = value
        End Set
    End Property

End Class
