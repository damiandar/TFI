<%@ Control Language="VB" AutoEventWireup="false" CodeFile="motivos.ascx.vb" Inherits="controles_motivos" %>
<style type="text/css">

.tablaFila1
{
    BACKGROUND-IMAGE: url('../assets/images/tablaFila1.gif');
    HEIGHT: 30px
    }
.tablaFila2
{
    BACKGROUND-IMAGE: url('../assets/images/tablaFila2.gif');
    HEIGHT: 30px
    }
</style>

   <div class="tablaSeparador2">
   <asp:Panel ID="PanelImportante" runat="server">
    <table width="715" border="0" cellspacing="0" cellpadding="5">
    <tr class="tablaTitulo1"><td height="30">Importante</td></tr>      
           <tr><td ><asp:Label ID="lblAdvertencia" runat="server" Text=""></asp:Label></td></tr>        
    </table>
    </asp:Panel>
    <table width="715" border="0" cellspacing="0" cellpadding="5">
                   <tr class="tablaTitulo1"><td height="30">Motivos</td></tr>              

    </table>
    <asp:GridView ID="GrillaMotivos" EmptyDataText="No hay productos cargados"  ShowHeader="false"   
           runat="server" DataKeyNames="codigo,descripcion" AutoGenerateColumns="False" BorderStyle="None"  >
   
        <Columns>
            <asp:TemplateField HeaderText="Código" SortExpression="codigo" HeaderStyle-BorderStyle="None" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" >
               <HeaderStyle Width="50px" Font-Bold="false"  />
                <ItemTemplate>
                      <asp:Image runat="server" ImageUrl= '<%# llenarimagen( Eval("codigo")) %>' /> 
                </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="descripcion" ItemStyle-HorizontalAlign="Center" HeaderText="Motivo" HeaderStyle-Font-Bold="false" HeaderStyle-BorderStyle="None" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-HorizontalAlign="Left" >
                   <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</div>    


    