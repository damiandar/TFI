<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="graficos.aspx.vb" Inherits="micuenta_Default" %>

<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Datos" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Chart ID="Chart2" runat="server">
        <Series>
            <asp:Series CustomProperties="DrawingStyle=Emboss" Name="Series1">
            </asp:Series>
        </Series>
        <Legends>
            <asp:Legend Name="Legend1" Title="Totales">
            </asp:Legend>
        </Legends>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    Año:
    <asp:DropDownList ID="comboAnio" runat="server" AutoPostBack="True">
    </asp:DropDownList>
          <asp:Chart ID="Chart1" runat="server">
        <Series>
            <asp:Series Name="Series1" CustomProperties="DrawingStyle=Emboss" >
            </asp:Series>
        </Series>
                    <Legends>
                <asp:Legend Name="Legend1" Title="Productos"  >
                </asp:Legend>
            </Legends>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
 
    <asp:GridView ID="GrillaDetalle" CssClass="listing" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Codigo Producto" DataField="id" />
            <asp:BoundField HeaderText="Cantidad" DataField="descripcion" />
            <asp:BoundField HeaderText="Total Gastado" DataField="total" DataFormatString="{0:c}" ItemStyle-Width="40px"  ItemStyle-HorizontalAlign="Right"/>
        </Columns>
    </asp:GridView>
</asp:Content>

