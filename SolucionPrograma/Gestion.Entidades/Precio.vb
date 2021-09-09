
Public Class Precio

    Public Sub New()

    End Sub

    Public Sub New(ByVal dValor As Double, ByVal Iva As IVA)
        pValor = dValor
        pIVA = Iva
    End Sub


    Public Sub New(ByVal ProductoID As Integer, ByVal dValor As Double, ByVal Iva As IVA)
        pValor = dValor
        pIVA = Iva
    End Sub

    Private pValor As Double
    Public Property ValorUnitario() As Double
        Get
            Return pValor
        End Get
        Set(ByVal value As Double)
            pValor = value
        End Set
    End Property


    Private pIVA As IVA
    Public Property iva() As IVA
        Get
            Return pIVA
        End Get
        Set(ByVal value As IVA)
            pIVA = value
        End Set
    End Property

    ''' <summary>
    ''' Precio con impuestos
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ValorFinal() As Double
        Get
            Return pValor * pIVA.Multiplicador
        End Get
    End Property


End Class
