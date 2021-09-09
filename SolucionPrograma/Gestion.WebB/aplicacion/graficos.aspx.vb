Imports System.Web.UI.DataVisualization.Charting

Partial Class micuenta_Default
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LLenarComboAnio()
            llenargraficoBarras()
            llenargraficoTorta()
        End If
    End Sub

    Private Sub llenargraficoBarras()
        Dim ListaEstadisticas As New List(Of Estadistica)
        Dim GestorEstadistica As New BLLEstadisticas
        ListaEstadisticas = GestorEstadistica.EstadisticaPedido(0)



        Chart2.BorderSkin.SkinStyle = BorderSkinStyle.Emboss
        ' Set Background Primary Color
        Chart2.BorderSkin.BackColor = Drawing.Color.Red
        ' Set Background Secondary Color
        Chart2.BorderSkin.BackSecondaryColor = Drawing.Color.Blue
        ' Set Hatch Style
        Chart2.BorderSkin.BackHatchStyle = ChartHatchStyle.DarkVertical
        ' Set Gradient Type
        Chart2.BorderSkin.BackGradientStyle = GradientStyle.DiagonalRight
        ' Set Border Color
        Chart2.BorderSkin.BorderColor = Drawing.Color.Yellow
        ' Set Border Style
        Chart2.BorderSkin.BorderDashStyle = ChartDashStyle.Solid
        ' Set Border Width
        Chart2.BorderSkin.BorderWidth = 2

        'Chart2.Series("Default").Color = Drawing.Color.MediumSeaGreen
        'Chart2.Series("Default").BackSecondaryColor = Drawing.Color.Green
        'Chart2.Series("Default").BackGradientStyle = GradientStyle.DiagonalLeft

        'Chart2.Series("Default").BorderColor = Drawing.Color.Black
        'Chart2.Series("Default").BorderWidth = 2
        'Chart2.Series("Default").BorderDashStyle = ChartDashStyle.Solid

        'Chart2.Series("Default").ShadowOffset = 2


        Chart2.Height = Unit.Pixel(300)
        Chart2.Width = Unit.Pixel(600)


        'Chart2.Series(0).ChartType = SeriesChartType.Pi

        For Each UnaEstadistica As Estadistica In ListaEstadisticas
            Dim p As New DataPoint
            'p.SetValueY(UnaEstadistica.Descripcion)
            p.AxisLabel = UnaEstadistica.ID
            p.SetValueXY(UnaEstadistica.Descripcion, UnaEstadistica.Valor)
            p.PostBackValue = UnaEstadistica.ID
            p.ToolTip = String.Format("{0:c}", UnaEstadistica.Valor)
            'series_monkeys.Points.Add(p)
            Chart2.Series(0).Points.Add(p)

            Dim p2 As New DataPoint
            'p.SetValueY(UnaEstadistica.Descripcion)
            p2.AxisLabel = UnaEstadistica.ID
            p2.SetValueXY(UnaEstadistica.Descripcion, UnaEstadistica.Valor + 15)
            p2.PostBackValue = UnaEstadistica.ID
            p2.ToolTip = String.Format("{0:c}", UnaEstadistica.Valor)
            'series_monkeys.Points.Add(p)
            Chart2.Series(1).Points.Add(p2)
        Next
    End Sub

    Private Sub llenargraficoTorta()
        Dim ListaEstadisticas As New List(Of Estadistica)

        ListaEstadisticas.Add(New Estadistica(1, "ventas servicio 1", 2400))

        ListaEstadisticas.Add(New Estadistica(2, "gastos anuales", 1800))
        ListaEstadisticas.Add(New Estadistica(3, "ventas servicio 2", 3300))
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
    Private Sub LLenarComboAnio()
        Dim AnioActual As Integer = Now.Year
        For i = AnioActual - 10 To AnioActual
            comboAnio.Items.Add(New ListItem(i, i))
        Next
    End Sub

    Protected Sub comboAnio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboAnio.SelectedIndexChanged
        llenargraficoBarras()
    End Sub

    Protected Sub Chart2_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart2.Click
        Dim valor As Integer = Convert.ToInt32(e.PostBackValue)
    End Sub

End Class
