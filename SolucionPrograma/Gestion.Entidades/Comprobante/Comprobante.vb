
Public Class Comprobante

    Public Enum eTipo
        FAC = 1
        NC = 2
        ND = 3
        OC = 4
        REMITO = 5
    End Enum

    Private pTipo As eTipo
    Public Property Tipo() As eTipo
        Get
            Return pTipo
        End Get
        Set(ByVal value As eTipo)
            pTipo = value
        End Set
    End Property

    Private pid As Integer
    Public Property ID As Integer
        Get
            Return pid
        End Get
        Set(ByVal value As Integer)
            pid = value
        End Set
    End Property
    'fecha carga
    Private pfecha As Date
    Public Property Fecha As Date
        Get
            Return pfecha
        End Get
        Set(ByVal value As Date)
            pfecha = value
        End Set
    End Property

    'Si entra en el balance o no
    Private pImputable As Boolean
    Public Property Imputable() As Boolean
        Get
            Return pImputable
        End Get
        Set(ByVal value As Boolean)
            pImputable = value
        End Set
    End Property

    Private pNotas As String
    Public Property Notas() As String
        Get
            Return pNotas
        End Get
        Set(ByVal value As String)
            pNotas = value
        End Set
    End Property


End Class
