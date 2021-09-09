Imports System.Web.UI.DataVisualization.Charting

Partial Class backend_encuestas_Detalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim EncuestaID As Integer = Request.QueryString("EncuestaID")
        If EncuestaID > 0 Then
            Dim GestorEncuestas As New BLLEncuesta()
            Dim UnaEncuesta As New Encuesta
            UnaEncuesta = GestorEncuestas.MostrarEncuesta(EncuestaID)
            lblEncuesta.Text = UnaEncuesta.Descripcion

            GrillaEncuestas.DataSource = UnaEncuesta.Opciones
            GrillaEncuestas.DataBind()
            llenargraficoTorta(EncuestaID)
        Else
            Response.Redirect("~/backend/encuestas/Default.aspx")
        End If

    End Sub


    Private Sub llenargraficoTorta(ByVal EncuestaID As Integer)
        Dim ListaEstadisticas As New List(Of Estadistica)
        Dim GestorEstadisticas As New BLLEstadisticas
        ListaEstadisticas = GestorEstadisticas.EstadisticaEncuesta(EncuestaID)

        Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss
        ' Set Background Primary Color
        Chart1.BorderSkin.BackColor = Drawing.Color.Red
        ' Set Background Secondary Color
        Chart1.BorderSkin.BackSecondaryColor = Drawing.Color.Blue
        ' Set Hatch Style
        Chart1.BorderSkin.BackHatchStyle = ChartHatchStyle.DarkVertical
        ' Set Gradient Type
        Chart1.BorderSkin.BackGradientStyle = GradientStyle.DiagonalRight
        ' Set Border Color
        Chart1.BorderSkin.BorderColor = Drawing.Color.Yellow
        ' Set Border Style
        Chart1.BorderSkin.BorderDashStyle = ChartDashStyle.Solid
        ' Set Border Width
        Chart1.BorderSkin.BorderWidth = 2


        Chart1.Height = Unit.Pixel(300)
        Chart1.Width = Unit.Pixel(400)


        Chart1.Series(0).ChartType = SeriesChartType.Pie

        For Each UnaEstadistica As Estadistica In ListaEstadisticas
            Dim p As New DataPoint
            'p.SetValueY(UnaEstadistica.Descripcion)
            p.AxisLabel = UnaEstadistica.ID
            p.SetValueXY(UnaEstadistica.Descripcion, UnaEstadistica.Valor)
            p.PostBackValue = UnaEstadistica.ID
            p.ToolTip = String.Format("{0:c}", UnaEstadistica.Valor)
            'series_monkeys.Points.Add(p)
            Chart1.Series(0).Points.Add(p)
        Next
    End Sub
End Class
