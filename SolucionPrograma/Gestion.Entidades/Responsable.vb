Public Class ResponsabilidadFiscal

    Public Sub New()

    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Descripcion As String)
        Me.ID = ID
        Me.Descripcion = Descripcion
    End Sub

    Private pId As Integer
    Public Property ID() As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
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

End Class
