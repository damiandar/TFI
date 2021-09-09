Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.html
Imports System.IO


Partial Class micuenta_Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim GestorReportes As New Reportes()

        'Dim output As MemoryStream = GestorReportes.DibujarPlanillaPedidos()
        'HttpContext.Current.Response.ContentType = "application/pdf"
        'HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Planilla_Pedido-{0}.pdf", "aaa"))
        'HttpContext.Current.Response.BinaryWrite(output.ToArray())
    End Sub



   
End Class
