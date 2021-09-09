Public Class Categoria

    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
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

    Private pSubCategorias As List(Of SubCategoria)
    Public Property SubCategorias() As List(Of SubCategoria)
        Get
            Return pSubCategorias
        End Get
        Set(ByVal value As List(Of SubCategoria))
            pSubCategorias = value
        End Set
    End Property

End Class
