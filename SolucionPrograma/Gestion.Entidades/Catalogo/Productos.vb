
Public Class Productos
    Inherits Catalogo

    Private pCodigoInterno As String
    Public Property CodigoInterno() As String
        Get
            Return pCodigoInterno
        End Get
        Set(ByVal value As String)
            pCodigoInterno = value
        End Set
    End Property

    Private pTipoImagen As String
    Public Property TipoImagen() As String
        Get
            Return pTipoImagen
        End Get
        Set(ByVal value As String)
            pTipoImagen = value
        End Set
    End Property

    Private pImagen As Byte()
    Public Property Imagen() As Byte()
        Get
            Return pImagen
        End Get
        Set(ByVal value As Byte())
            pImagen = value
        End Set
    End Property

    Private pStock As Stock
    Public Property stock() As Stock
        Get
            Return pStock
        End Get
        Set(ByVal value As Stock)
            pStock = value
        End Set
    End Property

    Private pComentarios As List(Of Comentarios)
    Public Property comentarios() As List(Of Comentarios)
        Get
            Return pComentarios
        End Get
        Set(ByVal value As List(Of Comentarios))
            pComentarios = value
        End Set
    End Property

    Private pTiempoEntrega As Integer
    Public Property TiempoEntrega() As Integer
        Get
            Return pTiempoEntrega
        End Get
        Set(ByVal value As Integer)
            pTiempoEntrega = value
        End Set
    End Property

    Private pDestacado As Boolean
    Public Property Destacado() As Boolean
        Get
            Return pDestacado
        End Get
        Set(ByVal value As Boolean)
            pDestacado = value
        End Set
    End Property


    Public ReadOnly Property Puntaje() As Double
        Get
            Dim valorpuntaje As Integer = 0

            If pComentarios IsNot Nothing Then
                If Me.pComentarios.Count > 0 Then
                    valorpuntaje = pComentarios.Sum(Function(x) x.Puntaje)
                    valorpuntaje = (valorpuntaje / Me.pComentarios.Count) * 10
                End If
            End If

            Return valorpuntaje
        End Get
    End Property


    Public Sub New()

    End Sub
    Public Sub New(ByVal pId As Integer, ByVal pNombreCorto As String, ByVal pNombreLargo As String)
        Me.ID = pId
        Me.NombreCorto = pNombreCorto
        Me.NombreLargo = pNombreLargo
    End Sub
End Class
