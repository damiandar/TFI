<%@ Control Language="VB" AutoEventWireup="false" CodeFile="encuestas.ascx.vb" Inherits="controles_encuestas" %>
<asp:Panel ID="PanelEncuestas" runat="server">

<div id="content-right" class="span5" >

<div class="block block-bordered block-poll">
<div class="block-title">Encuesta</div>
<div class="block-body listbox">
        
<div id="poll-block-1" class="poll-item equalized-column" data-equalized-deep="true" style="padding-left:10px;">
    <div class="poll-display-text" data-equalized-part="name">
        <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label> 
    </div>
    <div class="poll-take-poll">
        <div data-equalized-part="data">
        <asp:DataList ID="GrillaEncuestaDetalle" runat="server">
        <ItemTemplate>
            <label class="radio">
                <input type="radio" id="Opcion" name="Opcion" value='<%#Eval("id") %>'  />
                <asp:Label ID="lblDescripcion" runat="server" Text='<%#Eval("detalle") %>'></asp:Label>
            </label>
        </ItemTemplate>
        </asp:DataList>
        </div>
        <asp:LinkButton ID="lnkVotar" runat="server"     CssClass="btn btn-warning btn-block ">Votar</asp:LinkButton>
    </div>
</div>

</div>
</div>

</div>

    
</asp:Panel>