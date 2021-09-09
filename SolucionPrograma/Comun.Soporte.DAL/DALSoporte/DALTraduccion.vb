Imports System.Data
Imports System.Data.SqlClient


Public Class DALTraduccion

    Dim Conectividad As Conector
    Public Sub New()
        Conectividad = New Conector()
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' Actualiza una traducción.
    ''' </summary>
    ''' <param name="UnMensaje"></param>
    ''' <remarks></remarks>
    Public Sub Actualizar(ByVal UnMensaje As Traduccion)
        Dim ParId As New SqlParameter("@id_idioma", SqlDbType.Int, 0)
        ParId.Value = UnMensaje.IdIdioma

        Dim ParSin As New SqlParameter("@nombre", SqlDbType.VarChar, 50)
        ParSin.Value = UnMensaje.Nombre

        Dim ParCon As New SqlParameter("@valor", SqlDbType.VarChar, 50)
        ParCon.Value = UnMensaje.Valor

        Conectividad.EjecutarComando("update sop_traducciones set con_Traduccion=@valor where id_idioma=@id_idioma and sin_traduccion=@nombre", New SqlParameter() {ParId, ParCon, ParSin})
    End Sub

    ''' <summary>
    ''' Inserta una traducción.
    ''' </summary>
    ''' <param name="UnMensaje"></param>
    ''' <remarks></remarks>
    Public Sub Insertar(ByVal UnMensaje As Traduccion)
        Dim ParId As New SqlParameter("@id_idioma", SqlDbType.Int, 0)
        ParId.Value = UnMensaje.IdIdioma

        Dim ParSin As New SqlParameter("@nombre", SqlDbType.VarChar, 50)
        ParSin.Value = UnMensaje.Nombre

        Dim ParCon As New SqlParameter("@valor", SqlDbType.VarChar, 50)
        ParCon.Value = UnMensaje.Valor

        Conectividad.EjecutarComando("insert into sop_traducciones values(@id_idioma,@nombre,@valor)", New SqlParameter() {ParId, ParCon, ParSin})

    End Sub

    ''' <summary>
    ''' Muestra un diccionario de palabras del idioma seleccionado.
    ''' </summary>
    ''' <param name="ididioma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarDiccionario(ByVal ididioma As Integer) As Dictionary(Of String, String)
        Dim ParId As New SqlParameter("@id_idioma", SqlDbType.Int, 0)
        ParId.Value = ididioma
        Dim dt As DataTable = Conectividad.MostrarDataTable("select distinct * from sop_traducciones where id_idioma=@id_idioma", New SqlParameter() {ParId})
        Dim dictionary As New Dictionary(Of String, String)
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                dictionary.Add(fila("sin_traduccion").ToString(), fila("con_traduccion").ToString())
            Next
        End If
        Return dictionary
    End Function

    ''' <summary>
    ''' Muestra todas las traducciones de un idioma seleccionado.
    ''' </summary>
    ''' <param name="idIdioma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Listar(ByVal idIdioma As Integer) As List(Of Traduccion)

        Dim ParId As New SqlParameter("@id_idioma", SqlDbType.Int, 0)
        ParId.Value = idIdioma

        Dim ListaMensajes As New List(Of Traduccion)

        Dim dt As DataTable = Conectividad.MostrarDataTable("select * from sop_traducciones where id_idioma=@id_idioma", New SqlParameter() {ParId})

        For Each fila As DataRow In dt.Rows
            ListaMensajes.Add(ConstruirObjetoConRegistro(fila))
        Next

        Return ListaMensajes

    End Function

#End Region

#Region "Metodos Privados"

    Public Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Traduccion
        Dim UnMensaje As New Traduccion
        UnMensaje.IdIdioma = Convert.ToInt32(fila("id_idioma"))
        UnMensaje.Nombre = fila("sin_traduccion").ToString().Trim()
        UnMensaje.Valor = fila("con_traduccion").ToString()
        Return UnMensaje
    End Function

#End Region



End Class
