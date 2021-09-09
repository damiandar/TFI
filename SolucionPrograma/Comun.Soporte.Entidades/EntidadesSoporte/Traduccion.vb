Public Class Traduccion

#Region "Variables"
    Private VIdIdioma As Integer
    Private VValor As String
    Private VNombre As String

#End Region

#Region "Propiedades"

    Public Property IdIdioma() As Integer
        Get
            Return VIdIdioma
        End Get
        Set(ByVal value As Integer)
            VIdIdioma = value
        End Set
    End Property

    Public Property Valor() As String
        Get
            Return VValor
        End Get
        Set(ByVal value As String)
            VValor = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return VNombre
        End Get
        Set(ByVal value As String)
            VNombre = value
        End Set
    End Property

#End Region

End Class
