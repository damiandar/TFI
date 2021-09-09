Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.html

Imports System.IO

Public Class Reportes

    Dim document As Document

    Public Sub New()
        'Creo un nuevo documento
        document = New Document(PageSize.A4, 50, 50, 10, 25)
        'Se define algunas propiedades
        document.AddTitle("Planilla Pedido" & "Hola")
        document.AddSubject("Planilla pedidos")
        document.AddKeywords("dd, Pedidos, Planilla")
        document.AddCreator("ddd")
        document.AddAuthor("dd")
    End Sub

    'VENTAS/CLIENTE
    Public Function DibujarPlanillaPedidos(ByVal RutaDestino As String, ByVal UnPedido As Pedido) As MemoryStream

        'Se crea un nuevo objeto PDFWriter y otro objeto MemoryStream para escribir la salida del mismo
        Dim output As New MemoryStream()
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, output)
        'Para agregar pie de página (Los pie de página y encabezados se deben agregar antes de abrir el documento)
        'Dim footer As New Phrase("Sello:" & vbCrLf & "Firma y Aclaración:")
        'Dim piepagina As New HeaderFooter(footer, False)
        'piepagina.Border = Rectangle.NO_BORDER
        'piepagina.Alignment = 1
        'document.Footer = piepagina
        'Se abre el documento para escribir.
        document.Open()
        document.Add(New Paragraph(vbCrLf))
        document.Add(New Paragraph(vbCrLf))

        Dim table As New PdfPTable(4)  'CREO UNA TABLA

        Dim cell = New PdfPCell(New Phrase(String.Format("PEDIDO  {0}", UnPedido.ID, New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.GREEN))))
        cell.Colspan = 4
        cell.HorizontalAlignment = 0 '0=Left, 1=Centre, 2=Right

        cell.BackgroundColor = iTextSharp.text.Color.GREEN
        table.AddCell(cell)
        cell = New PdfPCell(New Phrase("Nro: ", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        table.AddCell(cell)
        table.AddCell(UnPedido.ID)
        table.AddCell(New PdfPCell(New Phrase("Fecha de solicitud:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(Now.ToShortDateString())
        table.AddCell(New PdfPCell(New Phrase("Cliente:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnPedido.cliente.Razon.ToString())
        table.AddCell(New PdfPCell(New Phrase("CUIT:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnPedido.cliente.CUIT)
        Cell = New PdfPCell(New Phrase("Resp. Fiscal:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        Cell.Colspan = 2
        table.AddCell(cell)
        cell = New PdfPCell(New Phrase(UnPedido.cliente.Responsable.Descripcion))
        cell.Colspan = 2
        table.AddCell(cell)

        table.AddCell(New PdfPCell(New Phrase("Domicilio:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        cell = New PdfPCell(New Phrase(UnPedido.cliente.Domicilio))
        cell.Colspan = 3
        table.AddCell(cell)
        table.HorizontalAlignment = 1

        table.AddCell(New PdfPCell(New Phrase("Localidad:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnPedido.cliente.Localidad)
        table.AddCell(New PdfPCell(New Phrase("Provincia:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnPedido.cliente.Provincia.Descripcion)

        document.Add(table)   'AGREGO LA TABLA
        document.Add(New Paragraph(vbCrLf))
        table = New PdfPTable(6)
        table.TotalWidth = 300.0F
        Dim width() As Single = {0.5F, 1.0F, 3.0F, 1.0F, 1.0F, 1.0F}
        table.SetWidths(width)
        'cell = New PdfPCell(New Phrase("Items del Pedido", New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.BLACK)))
        'cell.Colspan = 6
        'cell.HorizontalAlignment = 1 '0=Left, 1=Centre, 2=Right
        'table.AddCell(cell)
        table.AddCell(New PdfPCell(New Phrase("Nro", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("CODIGO", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Descrip.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Cant.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Precio", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("SubTotal", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        Dim numItem As Integer = 1

        For Each UnItem In UnPedido.Items
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.producto.CodigoInterno, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.producto.NombreLargo, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            cell = New PdfPCell(New Phrase(UnItem.cantidad, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK)))
            cell.HorizontalAlignment = 1
            table.AddCell(cell)
            cell = New PdfPCell(New Phrase(UnItem.producto.precio.ValorFinal, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK)))
            cell.HorizontalAlignment = 2
            table.AddCell(cell)
            cell = New PdfPCell(New Phrase(UnItem.producto.precio.ValorFinal * UnItem.cantidad, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK)))
            cell.HorizontalAlignment = 2
            table.AddCell(cell)
            numItem += 1
        Next

        For i = UnPedido.Items.Count + 1 To 10
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            numItem += 1
        Next

        table.HorizontalAlignment = 1

        cell = New PdfPCell(New Phrase("Total", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 5
        cell.HorizontalAlignment = 2 '0=Left, 1=Centre, 2=Right
        table.AddCell(cell)
        Dim Suma As Double = UnPedido.Items.Sum(Function(x) x.Total)
        table.AddCell(New PdfPCell(New Phrase(Suma.ToString("c"), New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
        document.Add(table) 'AGREGO TABLA


        'document.Add(New Paragraph(vbCrLf))
        'document.Add(New Paragraph(vbCrLf))
        'document.Add(New Phrase("Sello:" & vbCrLf & "Firma y Aclaración:"))
        'document.Add(New Paragraph(document.BottomMargin, "Sello:" & vbCrLf & "Firma y Aclaración:"))
        document.Close()
        'HttpContext.Current.Response.ContentType = "application/pdf"
        'HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Planilla_Pedido-{0}.pdf", "aaa"))
        'HttpContext.Current.Response.BinaryWrite(output.ToArray())
        Return output
    End Function
    'ORDENES/PROVEEDOR
    Public Function DibujarPlanillaOrdenes(ByVal RutaDestino As String, ByVal UnaOrden As OrdenCompra) As MemoryStream

        'Se crea un nuevo objeto PDFWriter y otro objeto MemoryStream para escribir la salida del mismo
        Dim output As New MemoryStream()
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, output)
        'Para agregar pie de página (Los pie de página y encabezados se deben agregar antes de abrir el documento)
        'Dim footer As New Phrase("Sello:" & vbCrLf & "Firma y Aclaración:")
        'Dim piepagina As New HeaderFooter(footer, False)
        'piepagina.Border = Rectangle.NO_BORDER
        'piepagina.Alignment = 1
        'document.Footer = piepagina
        'Se abre el documento para escribir.
        document.Open()


        Dim encab As New PdfPTable(3)
        Dim table As New PdfPTable(2)
        Dim widths() As Single = {0.5F, 2.5F}
        table.SetWidths(widths)
        'Dim img As Image = Image.GetInstance(ruta)
        'img.ScalePercent(32.0F)
        'Dim cell As New PdfPCell(img)
        'cell.Border = 0
        'cell.VerticalAlignment = Element.ALIGN_MIDDLE
        'cell.HorizontalAlignment = 1
        'table.AddCell(cell)
        'Dim cell As New PdfPCell(img)
        Dim cell As New PdfPCell(New Phrase("aaaaaaaaaaaaaaaaaaaaaaaa", New Font(Font.HELVETICA, 10.0F, Font.BOLD, Color.BLACK)))
        cell.HorizontalAlignment = 1
        cell.Colspan = 3
        cell.Border = 0
        encab.AddCell(cell)

        cell = New PdfPCell(encab)
        cell.Border = 0
        table.AddCell(cell)
        document.Add(table)


        document.Add(New Paragraph(vbCrLf))
        document.Add(New Paragraph(vbCrLf))


        table = New PdfPTable(4)

        cell = New PdfPCell(New Phrase(String.Format("ORDEN DE COMPRA  {0}", " ", New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.BLACK))))
        cell.Colspan = 4
        cell.HorizontalAlignment = 0 '0=Left, 1=Centre, 2=Right
        table.AddCell(cell)
        table.AddCell(New PdfPCell(New Phrase("Nro: ", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnaOrden.ID)
        table.AddCell(New PdfPCell(New Phrase("Fecha de solicitud:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(Now.ToShortDateString())
        table.AddCell(New PdfPCell(New Phrase("Cliente:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnaOrden.proveedor.Razon.ToString())
        table.AddCell(New PdfPCell(New Phrase("CUIT:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnaOrden.proveedor.CUIT)
        cell = New PdfPCell(New Phrase("Resp. Fiscal:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 1
        table.AddCell(cell)
        cell = New PdfPCell(New Phrase(UnaOrden.proveedor.Responsable.Descripcion))
        cell.Colspan = 3
        table.AddCell(cell)

        table.AddCell(New PdfPCell(New Phrase("Domicilio:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        cell = New PdfPCell(New Phrase(UnaOrden.proveedor.Domicilio))
        cell.Colspan = 3
        table.AddCell(cell)
        table.HorizontalAlignment = 1

        table.AddCell(New PdfPCell(New Phrase("Localidad:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnaOrden.proveedor.Localidad)
        table.AddCell(New PdfPCell(New Phrase("Provincia:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnaOrden.proveedor.Provincia.Descripcion)

        document.Add(table)
        document.Add(New Paragraph(vbCrLf))

        table = New PdfPTable(5)
        table.TotalWidth = 300.0F
        Dim width() As Single = {0.5F, 1.0F, 4.0F, 1.0F, 1.0F}
        table.SetWidths(width)
        cell = New PdfPCell(New Phrase("Detalle", New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 5
        cell.HorizontalAlignment = 1 '0=Left, 1=Centre, 2=Right
        table.AddCell(cell)
        table.AddCell(New PdfPCell(New Phrase("Nro", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("CODIGO", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Descrip.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Cant.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Precio", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        Dim numItem As Integer = 1

        For Each UnItem In UnaOrden.Items
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.insumo.ID, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.insumo.NombreCorto, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.cantidad, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.precio, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            numItem += 1
        Next

        For i = UnaOrden.Items.Count + 1 To 10
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            numItem += 1
        Next

        table.HorizontalAlignment = 1

        cell = New PdfPCell(New Phrase("Total", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 4
        cell.HorizontalAlignment = 2 '0=Left, 1=Centre, 2=Right
        table.AddCell(cell)
        table.AddCell(New PdfPCell(New Phrase(UnaOrden.Items.Sum(Function(x) x.Total), New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))

        document.Add(table)
        'document.Add(New Paragraph(vbCrLf))
        'document.Add(New Paragraph(vbCrLf))
        'document.Add(New Phrase("Sello:" & vbCrLf & "Firma y Aclaración:"))
        'document.Add(New Paragraph(document.BottomMargin, "Sello:" & vbCrLf & "Firma y Aclaración:"))
        document.Close()
        'HttpContext.Current.Response.ContentType = "application/pdf"
        'HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Planilla_Pedido-{0}.pdf", "aaa"))
        'HttpContext.Current.Response.BinaryWrite(output.ToArray())
        Return output
    End Function
    'ABASTECIMIENTO/interno
    Public Function DibujarPlanillaAbastecimiento(ByVal RutaDestino As String, ByVal UnaReposicion As Reposicion) As MemoryStream

        'Se crea un nuevo objeto PDFWriter y otro objeto MemoryStream para escribir la salida del mismo
        Dim output As New MemoryStream()
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, output)
        'Para agregar pie de página (Los pie de página y encabezados se deben agregar antes de abrir el documento)
        'Dim footer As New Phrase("Sello:" & vbCrLf & "Firma y Aclaración:")
        'Dim piepagina As New HeaderFooter(footer, False)
        'piepagina.Border = Rectangle.NO_BORDER
        'piepagina.Alignment = 1
        'document.Footer = piepagina
        'Se abre el documento para escribir.
        document.Open()
        Dim enc As New PdfPTable(3)
        Dim table As New PdfPTable(2)
        Dim widths() As Single = {0.5F, 2.5F}
        table.SetWidths(widths)
        'Dim img As Image = Image.GetInstance(ruta)
        'img.ScalePercent(32.0F)
        'Dim cell As New PdfPCell(img)
        'cell.Border = 0
        'cell.VerticalAlignment = Element.ALIGN_MIDDLE
        'cell.HorizontalAlignment = 1
        'table.AddCell(cell)
        'Dim cell As New PdfPCell(img)
        Dim cell As New PdfPCell(New Phrase("aaaaaaaaaaaaaaaaaaaaaaaa", New Font(Font.HELVETICA, 10.0F, Font.BOLD, Color.BLACK)))
        cell.HorizontalAlignment = 1
        cell.Colspan = 3
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(New Phrase("bbbbbbbbbbbbbbbbbbbbbbbb", New Font(Font.HELVETICA, 8.0F, Font.BOLD, Color.BLACK)))
        cell.HorizontalAlignment = 1
        cell.Colspan = 3
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 8.0F, Font.BOLD, Color.BLACK)))
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 8.0F, Font.BOLD, Color.BLACK)))
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 8.0F, Font.BOLD, Color.BLACK)))
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(enc)
        cell.Border = 0
        table.AddCell(cell)
        document.Add(table)
        document.Add(New Paragraph(vbCrLf))
        document.Add(New Paragraph(vbCrLf))
        table = New PdfPTable(4)

        'cell = New PdfPCell(New Phrase(String.Format("PEDIDO  {0}", " ", New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.BLACK)))
        'cell.Colspan = 4
        'cell.HorizontalAlignment = 0 '0=Left, 1=Centre, 2=Right
        'table.AddCell(cell)
        table.AddCell(New PdfPCell(New Phrase("Nro: ", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnaReposicion.ID)
        table.AddCell(New PdfPCell(New Phrase("Fecha de solicitud:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(Now.ToShortDateString())
        table.AddCell(New PdfPCell(New Phrase("Cliente:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell("")
        table.AddCell(New PdfPCell(New Phrase("CUIT:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell("")
        cell = New PdfPCell(New Phrase("Resp. Fiscal:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 2
        table.AddCell(cell)
        cell = New PdfPCell(New Phrase(""))
        cell.Colspan = 2
        table.AddCell(cell)

        table.AddCell(New PdfPCell(New Phrase("Domicilio:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        cell = New PdfPCell(New Phrase(""))
        cell.Colspan = 3
        table.AddCell(cell)
        table.HorizontalAlignment = 1

        table.AddCell(New PdfPCell(New Phrase("Localidad:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell("")
        table.AddCell(New PdfPCell(New Phrase("Provincia:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell("")



        document.Add(table)
        document.Add(New Paragraph(vbCrLf))
        table = New PdfPTable(5)
        table.TotalWidth = 300.0F
        Dim width() As Single = {0.5F, 1.0F, 4.0F, 1.0F, 1.0F}
        table.SetWidths(width)
        cell = New PdfPCell(New Phrase("Items del Pedido", New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 5
        cell.HorizontalAlignment = 1 '0=Left, 1=Centre, 2=Right
        table.AddCell(cell)
        table.AddCell(New PdfPCell(New Phrase("Nro", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("CODIGO", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Descrip.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Cant.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Precio", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        Dim numItem As Integer = 1

        For Each UnItem In UnaReposicion.Items
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.insumo.ID, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.insumo.NombreLargo, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.cantidadPedida, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            numItem += 1
        Next

        For i = UnaReposicion.Items.Count + 1 To 10
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            numItem += 1
        Next

        table.HorizontalAlignment = 1

        cell = New PdfPCell(New Phrase("Total", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 4
        cell.HorizontalAlignment = 2 '0=Left, 1=Centre, 2=Right
        table.AddCell(cell)
        'table.AddCell(New PdfPCell(New Phrase(UnaReposicion.Items.Sum(Function(x) x.Total), New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))

        'document.Add(table)
        'document.Add(New Paragraph(vbCrLf))
        'document.Add(New Paragraph(vbCrLf))
        'document.Add(New Phrase("Sello:" & vbCrLf & "Firma y Aclaración:"))
        'document.Add(New Paragraph(document.BottomMargin, "Sello:" & vbCrLf & "Firma y Aclaración:"))
        document.Close()
        'HttpContext.Current.Response.ContentType = "application/pdf"
        'HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Planilla_Pedido-{0}.pdf", "aaa"))
        'HttpContext.Current.Response.BinaryWrite(output.ToArray())
        Return output
    End Function
    'REMITOS/PROVEEDOR
    Public Function DibujarPlanillaRemitos(ByVal RutaDestino As String, ByVal UnRemito As Remito) As MemoryStream
        'Se crea un nuevo objeto PDFWriter y otro objeto MemoryStream para escribir la salida del mismo
        Dim output As New MemoryStream()
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, output)
        document.Open()

        Dim tablaEncabezado As New PdfPTable(4)

        document.Add(New Paragraph(vbCrLf))
        document.Add(New Paragraph(vbCrLf))

        Dim cell = New PdfPCell(New Phrase(String.Format("REMITO  {0}", " ", New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.BLACK))))
        cell.Colspan = 4
        cell.HorizontalAlignment = 0 '0=Left, 1=Centre, 2=Right
        tablaEncabezado.AddCell(cell)

        tablaEncabezado.AddCell(New PdfPCell(New Phrase("Nro: ", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        tablaEncabezado.AddCell(UnRemito.ID)
        tablaEncabezado.AddCell(New PdfPCell(New Phrase("Fecha de entrega:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        tablaEncabezado.AddCell(Now.ToShortDateString())
        tablaEncabezado.AddCell(New PdfPCell(New Phrase("Proveedor:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        tablaEncabezado.AddCell(UnRemito.orden.proveedor.Razon.ToString())
        tablaEncabezado.AddCell(New PdfPCell(New Phrase("CUIT:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        tablaEncabezado.AddCell(UnRemito.orden.proveedor.CUIT)

        cell = New PdfPCell(New Phrase("Resp. Fiscal:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        Cell.Colspan = 1
        tablaEncabezado.AddCell(cell)
        cell = New PdfPCell(New Phrase(UnRemito.orden.proveedor.Responsable.Descripcion))
        cell.Colspan = 3
        tablaEncabezado.AddCell(cell)

        tablaEncabezado.AddCell(New PdfPCell(New Phrase("Domicilio:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        cell = New PdfPCell(New Phrase(UnRemito.orden.proveedor.Domicilio))
        cell.Colspan = 3
        tablaEncabezado.AddCell(cell)
        tablaEncabezado.HorizontalAlignment = 1

        tablaEncabezado.AddCell(New PdfPCell(New Phrase("Localidad:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        tablaEncabezado.AddCell(UnRemito.orden.proveedor.Localidad)
        tablaEncabezado.AddCell(New PdfPCell(New Phrase("Provincia:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        tablaEncabezado.AddCell(UnRemito.orden.proveedor.Provincia.Descripcion)
        document.Add(tablaEncabezado)

        document.Add(New Paragraph(vbCrLf))

        Dim table As New PdfPTable(4)
        table.TotalWidth = 300.0F
        Dim width() As Single = {0.5F, 1.0F, 4.0F, 1.0F}
        table.SetWidths(width)
        cell = New PdfPCell(New Phrase("Items del Pedido", New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 4
        cell.HorizontalAlignment = 1 '0=Left, 1=Centre, 2=Right
        table.AddCell(cell)
        table.AddCell(New PdfPCell(New Phrase("Nro", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("CODIGO", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Descrip.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Cant.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))

        Dim numItem As Integer = 1

        For Each UnItem In UnRemito.Items
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.insumo.ID, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.insumo.NombreLargo, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.cantidad, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            numItem += 1
        Next

        For i = UnRemito.Items.Count + 1 To 10
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            numItem += 1
        Next

        document.Add(table)
        document.Add(New Paragraph(vbCrLf))
        document.Add(New Paragraph(vbCrLf))
        document.Add(New Phrase("Sello:" & vbCrLf & "Firma y Aclaración:"))
        document.Close()
        Return output
    End Function

    'FACTURA/CLIENTE
    Public Function DibujarPlanillaFacturas(ByVal RutaDestino As String, ByVal UnaFactura As FacturaVenta) As MemoryStream

        'Se crea un nuevo objeto PDFWriter y otro objeto MemoryStream para escribir la salida del mismo
        Dim output As New MemoryStream()
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, output)
        document.Open()
        document.Add(New Paragraph(vbCrLf))
        document.Add(New Paragraph(vbCrLf))


        Dim cabecera As New PdfPTable(10)
        Dim celcab = New PdfPCell(New Phrase("LAVADERO BOUTIQUE"))
        celcab.Colspan = 4
        'celcab.
        cabecera.AddCell(celcab)
        celcab = New PdfPCell(New Phrase(String.Format("{0}", UnaFactura.Letra, New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.BLACK))))
        celcab.Colspan = 2
        celcab.HorizontalAlignment = 1
        cabecera.AddCell(celcab)
        celcab = New PdfPCell(New Phrase("Factura: ", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        celcab.Colspan = 4
        celcab.HorizontalAlignment = 1
        cabecera.AddCell(celcab)


        celcab = New PdfPCell(New Phrase("20-27152293-3"))
        celcab.Colspan = 5
        celcab.Padding = 10
        cabecera.AddCell(celcab)
        celcab = New PdfPCell(New Phrase("Nº: " & UnaFactura.Nro, New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        celcab.Colspan = 5
        celcab.HorizontalAlignment = 1
        cabecera.AddCell(celcab)
        document.Add(cabecera)


        Dim table As New PdfPTable(6)  'CREO UNA TABLA

        '----Primera FILA

        '----Segunda FILA
        Dim cell = New PdfPCell(New Phrase("Señor(es):", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        table.AddCell(cell)
        cell = New PdfPCell(New Phrase(UnaFactura.cliente.Razon.ToString(), New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 5
        table.AddCell(cell)
        '----Tercera FILA
        cell = New PdfPCell(New Phrase("Resp. Fiscal:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 2
        table.AddCell(cell)
        cell = New PdfPCell(New Phrase("")) 'cell = New PdfPCell(New Phrase(UnaFactura.cliente.Responsable.Descripcion))
        cell.Colspan = 2
        table.AddCell(cell)
        table.AddCell(New PdfPCell(New Phrase("CUIT:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(UnaFactura.cliente.CUIT)

        '----Cuarta FILA
        table.AddCell(New PdfPCell(New Phrase("Domicilio:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        cell = New PdfPCell(New Phrase("")) 'cell = New PdfPCell(New Phrase(UnaFactura.cliente.Domicilio))
        cell.Colspan = 3
        table.AddCell(cell)
        cell = New PdfPCell(New Phrase(""))
        table.AddCell(cell)
        cell = New PdfPCell(New Phrase(""))
        table.AddCell(cell)
        table.HorizontalAlignment = 1
        'Quinta FILA
        table.AddCell(New PdfPCell(New Phrase("Localidad:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell("")
        table.AddCell(New PdfPCell(New Phrase("Provincia:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        table.AddCell("")

        document.Add(table)   'AGREGO LA TABLA
        document.Add(New Paragraph(vbCrLf))
        table = New PdfPTable(5)
        table.TotalWidth = 300.0F
        Dim width() As Single = {0.5F, 3.0F, 1.0F, 1.0F, 1.0F}
        table.SetWidths(width)

        table.AddCell(New PdfPCell(New Phrase("Nro", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Descrip.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Cant.", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("Precio", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        table.AddCell(New PdfPCell(New Phrase("SubTotal", New Font(Font.HELVETICA, 11.0F, Font.BOLD, Color.BLACK))))
        Dim numItem As Integer = 1

        For Each UnItem In UnaFactura.Items
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase(UnItem.producto.NombreCorto, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            cell = New PdfPCell(New Phrase(UnItem.cantidad, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK)))
            cell.HorizontalAlignment = 1
            table.AddCell(cell)
            cell = New PdfPCell(New Phrase(UnItem.precio, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK)))
            cell.HorizontalAlignment = 2
            table.AddCell(cell)
            cell = New PdfPCell(New Phrase(UnItem.precio * UnItem.cantidad, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK)))
            cell.HorizontalAlignment = 2
            table.AddCell(cell)
            numItem += 1
        Next

        For i = UnaFactura.Items.Count + 1 To 10
            table.AddCell(New PdfPCell(New Phrase(numItem.ToString, New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            table.AddCell(New PdfPCell(New Phrase("", New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
            numItem += 1
        Next

        table.HorizontalAlignment = 1

        cell = New PdfPCell(New Phrase("Total", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 4
        cell.HorizontalAlignment = 2 '0=Left, 1=Centre, 2=Right
        table.AddCell(cell)
        Dim Suma As Double = UnaFactura.Total
        table.AddCell(New PdfPCell(New Phrase(Suma.ToString("c"), New Font(Font.HELVETICA, 10.0F, Font.NORMAL, Color.BLACK))))
        document.Add(table) 'AGREGO TABLA

        document.Close()
        Return output
    End Function

    Public Function ReporteConGrafico(ByVal Leyenda As String, ByVal ImagenGrafico As MemoryStream) As MemoryStream
        'Se crea un nuevo objeto PDFWriter y otro objeto MemoryStream para escribir la salida del mismo
        Dim output As New MemoryStream()
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, output)
        'Para agregar pie de página (Los pie de página y encabezados se deben agregar antes de abrir el documento)
        'Dim footer As New Phrase("Sello:" & vbCrLf & "Firma y Aclaración:")
        'Dim piepagina As New HeaderFooter(footer, False)
        'piepagina.Border = Rectangle.NO_BORDER
        'piepagina.Alignment = 1
        'document.Footer = piepagina
        'Se abre el documento para escribir.
        document.Open()
        Dim enc As New PdfPTable(3)
        Dim table As New PdfPTable(2)
        Dim widths() As Single = {0.5F, 2.5F}
        table.SetWidths(widths)
        'Dim img As Image = Image.GetInstance(ruta)
        'img.ScalePercent(32.0F)
        'Dim cell As New PdfPCell(img)
        'cell.Border = 0
        'cell.VerticalAlignment = Element.ALIGN_MIDDLE
        'cell.HorizontalAlignment = 1
        'table.AddCell(cell)
        'Dim cell As New PdfPCell(img)
        Dim cell As New PdfPCell(New Phrase("aaaaaaaaaaaaaaaaaaaaaaaa", New Font(Font.HELVETICA, 10.0F, Font.BOLD, Color.BLACK)))
        cell.HorizontalAlignment = 1
        cell.Colspan = 3
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(New Phrase("bbbbbbbbbbbbbbbbbbbbbbbb", New Font(Font.HELVETICA, 8.0F, Font.BOLD, Color.BLACK)))
        cell.HorizontalAlignment = 1
        cell.Colspan = 3
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(New Phrase("Domicilio", New Font(Font.HELVETICA, 8.0F, Font.BOLD, Color.BLACK)))
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(New Phrase("(11111) - Capital Federal", New Font(Font.HELVETICA, 8.0F, Font.BOLD, Color.BLACK)))
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(New Phrase("TE: 233246666", New Font(Font.HELVETICA, 8.0F, Font.BOLD, Color.BLACK)))
        cell.Border = 0
        enc.AddCell(cell)
        cell = New PdfPCell(enc)
        cell.Border = 0
        table.AddCell(cell)
        document.Add(table)
        document.Add(New Paragraph(vbCrLf))
        document.Add(New Paragraph(vbCrLf))
        table = New PdfPTable(4)
        cell = New PdfPCell(New Phrase("Pedido de compra", New Font(Font.HELVETICA, 18.0F, Font.BOLD, Color.BLACK)))
        cell.Colspan = 4
        cell.HorizontalAlignment = 0 '0=Left, 1=Centre, 2=Right
        table.AddCell(cell)
        table.AddCell(New PdfPCell(New Phrase("Notas:", New Font(Font.HELVETICA, 12.0F, Font.BOLD, Color.BLACK))))
        cell = New PdfPCell(New Phrase(Leyenda))
        cell.Colspan = 3
        table.AddCell(cell)
        table.HorizontalAlignment = 1
        document.Add(table)
        document.Add(New Paragraph(vbCrLf))

        Dim img As Image = Image.GetInstance(ImagenGrafico.ToArray())
        img.ScaleToFit(document.PageSize.Width - (document.LeftMargin + document.RightMargin),
                       document.PageSize.Height - (document.TopMargin + document.BottomMargin))
        document.Add(img)

        document.Add(New Paragraph(vbCrLf))
        document.Add(New Paragraph(vbCrLf))
        document.Add(New Phrase("Sello:" & vbCrLf & "Firma y Aclaración:"))
        'document.Add(New Paragraph(document.BottomMargin, "Sello:" & vbCrLf & "Firma y Aclaración:"))
        document.Close()
        'HttpContext.Current.Response.ContentType = "application/pdf"
        'HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Planilla_Pedido-{0}.pdf", "aaa"))
        'HttpContext.Current.Response.BinaryWrite(output.ToArray())
        Return output
    End Function

    Public Sub DibujarPDF(ByVal RutaPlantilla As String, ByVal RutaDestino As String, ByVal UnaFactura As ReportesCabecera, ByVal Items As List(Of ReportesItems))
        Try
            ' Create a Document object
            'Dim document As New Document(PageSize.A4.Rotate(), 50, 50, 25, 25)

            '// Setting Document properties e.g.
            '// 1. Title
            '// 2. Subject
            '// 3. Keywords
            '// 4. Creator    
            '// 5. Author
            '// 6. Header
            'document.AddTitle("Factura")
            'document.AddSubject("Comprobante Factura")
            'document.AddKeywords("Metadata, iTextSharp 5.4.4, Chapter 1, Tutorial")
            'document.AddCreator("Rosso")
            'document.AddAuthor("Debopam Pal")
            'document.AddHeader("Nothing", "No Header")

            'Create a new PdfWrite object, writing the output to a MemoryStream
            Dim output As New MemoryStream()
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(RutaDestino, FileMode.Create))

            'Open the Document for writing
            document.Open()

            'Read in the contents of the Receipt.htm HTML template file

            Dim contents As String = File.ReadAllText(RutaPlantilla) 'File.ReadAllText(Server.MapPath("~/HTMLTemplate/Receipt.htm"))


            ' Replace the placeholders with the user-specified text
            contents = contents.Replace("[ORDERID]", UnaFactura.NroFactura.ToString())
            contents = contents.Replace("[TIPO]", UnaFactura.TipoFactura.ToString())

            contents = contents.Replace("[TOTALPRICE]", Items.Sum(Function(x) x.TotalRenglon.ToString("c")))
            contents = contents.Replace("[CLIENTENOMBRE]", UnaFactura.RazonSocial)
            contents = contents.Replace("[CLIENTECUIT]", UnaFactura.CUIT)
            'contents = contents.Replace("[ORDERDATE]", UnaFactura.Fecha.ToShortDateString())

            Dim itemsTable As String = ""
            Dim i As Integer = 0
            For Each item As ReportesItems In Items
                i += 1
                itemsTable += String.Format("<tr><td class='clasecodigo'>{0}</td><td colspan=7>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>", i, item.Descripcion, item.Cantidad, item.PrecioUnitario.ToString("c"), item.TotalRenglon.ToString("c"))

            Next

            'itemsTable += "</table>"

            contents = contents.Replace("[ITEMS]", itemsTable)

            Dim styles As StyleSheet = New StyleSheet()

            'styles.LoadTagStyle(HtmlTags.BODY, HtmlTags.FONT, "35")
            styles.LoadTagStyle("table", "font-family", "verdana")
            styles.LoadTagStyle("table", "font-size", "55px")
            styles.LoadStyle("clasecodigo", "width", "20px")
            styles.LoadTagStyle("p", "background-color", "red")
            styles.LoadStyle("p", "style", "font-size: 8px; text-align: justify; font-family: Arial, Helvetica, sans-serif;font-color:red")
            Dim parsedHtmlElements = HTMLWorker.ParseToList(New StringReader(contents), styles)
            For Each htmlElement As IElement In parsedHtmlElements
                document.Add(htmlElement)
            Next

            'You can add additional elements to the document. Let's add an image in the upper right corner
            'var(logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/4guysfromrolla.gif")))
            'logo.SetAbsolutePosition(440, 800)
            'document.Add(logo)

            document.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

Public Class ReportesItems

    Public Sub New(ByVal codigo As String, ByVal descripcion As String, ByVal cantidad As Double, ByVal preciounitario As Double, ByVal ivaMultiplicativo As Double, ByVal ivaDescripcion As String, ByVal descuento As Double)
        Me.Codigo = codigo
        Me.Descripcion = descripcion
        Me.Cantidad = cantidad
        Me.PrecioUnitario = preciounitario
        Me.IVAMultiplicativo = ivaMultiplicativo
        Me.IVADescripcion = ivaDescripcion
        Me.Descuento = Descuento
    End Sub

    Private pCodigo As String
    Public Property Codigo() As String
        Get
            Return pCodigo
        End Get
        Set(ByVal value As String)
            pCodigo = value
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

    Private pPrecioUnitario As Double
    Public Property PrecioUnitario() As Double
        Get
            Return pPrecioUnitario
        End Get
        Set(ByVal value As Double)
            pPrecioUnitario = value
        End Set
    End Property

    Private pIVAMultiplicativo As Double
    Public Property IVAMultiplicativo() As Double
        Get
            Return pIVAMultiplicativo
        End Get
        Set(ByVal value As Double)
            pIVAMultiplicativo = value
        End Set
    End Property

    Private pIVADescripcion As String
    Public Property IVADescripcion() As String
        Get
            Return pIVADescripcion
        End Get
        Set(ByVal value As String)
            pIVADescripcion = value
        End Set
    End Property

    Private pDescuento As Double
    Public Property Descuento() As Double
        Get
            Return pDescuento
        End Get
        Set(ByVal value As Double)
            pDescuento = value
        End Set
    End Property

    Private pCantidad As Double
    Public Property Cantidad() As Double
        Get
            Return pCantidad
        End Get
        Set(ByVal value As Double)
            pCantidad = value
        End Set
    End Property

    Public ReadOnly Property TotalRenglon() As Double
        Get
            Return PrecioUnitario * Cantidad * IVAMultiplicativo
        End Get

    End Property

End Class

Public Class ReportesCabecera

    Private pCUIT As String
    Public Property CUIT() As String
        Get
            Return pCUIT
        End Get
        Set(ByVal value As String)
            pCUIT = value
        End Set
    End Property

    Private pTipoResponsable As String
    Public Property TipoResponsable() As String
        Get
            Return pTipoResponsable
        End Get
        Set(ByVal value As String)
            pTipoResponsable = value
        End Set
    End Property

    Private pRazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return pRazonSocial
        End Get
        Set(ByVal value As String)
            pRazonSocial = value
        End Set
    End Property

    Private pDomicilio As String
    Public Property Domicilio() As String
        Get
            Return pDomicilio
        End Get
        Set(ByVal value As String)
            pDomicilio = value
        End Set
    End Property

    Private pTelefono As String
    Public Property Telefono() As String
        Get
            Return pTelefono
        End Get
        Set(ByVal value As String)
            pTelefono = value
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

    Private pTipoFactura As String
    Public Property TipoFactura() As String
        Get
            Return pTipoFactura
        End Get
        Set(ByVal value As String)
            pTipoFactura = value
        End Set
    End Property

    Private pNroFactura As String
    Public Property NroFactura() As String
        Get
            Return pNroFactura
        End Get
        Set(ByVal value As String)
            pNroFactura = value
        End Set
    End Property

    Private pFecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return pFecha
        End Get
        Set(ByVal value As DateTime)
            pFecha = value
        End Set
    End Property

End Class
