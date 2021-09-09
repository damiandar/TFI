
Public Class CtaCte

    Private pCliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return pCliente
        End Get
        Set(ByVal value As Cliente)
            pCliente = value
        End Set
    End Property

    Public pComprobantes As List(Of CtaCteDetalle)
    Public Property comprobantes As List(Of CtaCteDetalle)
        Get
            Return pComprobantes
        End Get
        Set(ByVal value As List(Of CtaCteDetalle))
            pComprobantes = value
        End Set
    End Property

    Public ReadOnly Property Total() As Double
        Get
            Dim Retorno As Double = 0
            If Me.comprobantes IsNot Nothing Then
                If Me.comprobantes.Count > 0 Then
                    Retorno = comprobantes.Sum(Function(x) x.Monto)
                End If
            End If
            Return Retorno
        End Get
    End Property

End Class


Public Class CtaCteDetalle

    Public Enum Tipo
        Factura
        Pago
        NC
        ND
    End Enum

    Private pNro As Integer
    Public Property Nro() As Integer
        Get
            Return pNro
        End Get
        Set(ByVal value As Integer)
            pNro = value
        End Set
    End Property

    Private pId As Integer
    Public Property ID() As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
        End Set
    End Property

    Private pTipoComprobante As Tipo
    Public Property TipoComprobante() As Tipo
        Get
            Return pTipoComprobante
        End Get
        Set(ByVal value As Tipo)
            pTipoComprobante = value
        End Set
    End Property

    Private pMonto As Double
    Public Property Monto() As Double
        Get
            Return pMonto
        End Get
        Set(ByVal value As Double)
            pMonto = value
        End Set
    End Property

    Private pNota As String
    Public Property Nota() As String
        Get
            Return pNota
        End Get
        Set(ByVal value As String)
            pNota = value
        End Set
    End Property

    Private pFecha As Date
    Public Property Fecha() As Date
        Get
            Return pFecha
        End Get
        Set(ByVal value As Date)
            pFecha = value
        End Set
    End Property



End Class