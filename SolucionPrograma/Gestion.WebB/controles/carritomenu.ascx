<%@ Control Language="VB" AutoEventWireup="false" CodeFile="carritomenu.ascx.vb" Inherits="controles_carritomenu" %>
    <li class="dropdown">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-shopping-cart"></i> <b class="caret"></b></a>
        <ul class="dropdown-menu message-dropdown">
        <asp:DataList ID="Lista" runat="server" >
        <ItemTemplate>
            <li class="message-preview">
                <div class="media">
                    <span class="pull-left">
                        <asp:Image ID="Image1"  Width="50px" class="media-object"  runat="server" /> 
                    </span>
                    <div class="media-body">
                        <h5 class="media-heading"><strong><a href='<%#string.format("Detalle.aspx?producto_id={0}",Eval("producto.id")) %>' > <%#Eval("producto.nombrecorto")%></a></strong></h5>
                        <p class="small text-muted">Cant: <%#Eval("cantidad") %></p>
                        <p class="small text-muted"><%#String.Format("{0:C}",Eval("producto.precio.valorfinal")) %></p>
                        <p><%#Eval("producto.descripcion") %></p>
                    </div>
                </div>
            </li>
        </ItemTemplate> 
        </asp:DataList>
        <li class="message-footer">
            <asp:Label ID="lblTotalCarrito" runat="server" Text=""></asp:Label>  
        </li>
        <li class="message-footer"> 
            <asp:LinkButton PostBackUrl="~/frontend/Carrito.aspx" Text="Ir al carrito" ID="lnkCarrito" runat="server">   </asp:LinkButton>
        </li>
       
        </ul>
    </li>