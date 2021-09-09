
Public Class Mapper_DigitoVerificador
    Dim dataprovider As DALDigitoVerificador

    Public Sub New()
        dataprovider = New DALDigitoVerificador
    End Sub

    ''' <summary>
    ''' Actualizar Digito Verificador
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActualizarDigitoVerificador(ByVal tabla As String)
        dataprovider.ActualizarDigitoVerificador(tabla)
    End Sub

    ''' <summary>
    ''' Compara el digito verificador guardado en la base con el calculado actualmente.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function comprobarIntegridadBase() As Boolean
        Dim IntegridadComprobada As Boolean = False
        Dim dbGuardado As Double = dataprovider.MuestraDigitoVerificadorGuardado()

        Dim dbCalculo As Double = 0

        dbCalculo += dataprovider.MuestraDigitoVerificadorVertical("seg_usuario")
        'dbCalculo += dataprovider.MuestraDigitoVerificadorVertical("dal_producto")

        If dbGuardado = dbCalculo Then
            IntegridadComprobada = True
        End If

        Return IntegridadComprobada
    End Function

End Class
