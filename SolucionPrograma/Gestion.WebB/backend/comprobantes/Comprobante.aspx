<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Comprobante.aspx.vb" Inherits="aplicacion_forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <h1 class="page-header">
    Comprobantes
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Forms
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
</asp:ToolkitScriptManager>
<div class="row">
    <div  class="col-lg-6">
    <div role="form">
     <div class="form-group input-group">
            <input type="text" class="form-control"/>
            <span class="input-group-btn">
            <button class="btn btn-default" type="button"><i class="fa fa-search"></i></button>
                <asp:Button ID="btnNuevo" cssclass="btn btn-default" runat="server" Text="Nuevo" />
            </span>
    </div>
    </div>
       
    </div>

    <div class="col-lg-12">

                        <div role="form">

                            <div class="form-group">
                            
    <asp:GridView ID="GrillaComprobantes" runat="server">
    </asp:GridView>
                            </div>
                            </div>
   </div>
</div>
              <asp:Button ID="btnPopUp" runat="server" style="display:none" />

<asp:ModalPopupExtender ID="modalPopUpExtender1" runat="server" TargetControlID="btnPopUp" PopupControlID="pnlModalPopUp" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"  ></asp:ModalPopupExtender>
   
<asp:Panel runat="Server"  ID="pnlModalPopUp"   >

      <div id="detalleEvento"  style="width:100%; height:100%; z-index:5; display:block; position:absolute; left:0px; top: 0px; ">
      <div style="width:535px; height:500px; background-color:#FFF; border:solid 1px #000; position:absolute; left:50%; top:50%; margin-left:-267px; margin-top:-100px;">
        <div style="width:535px; height:40px; background-color:#676767;">
            <div style="color:#FFF; text-transform:capitalize; font-family: Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; float:left; margin-top:10px; margin-left:10px;">
            Bienvenida
            </div>
            
            <div style="float:right; margin-top:10px; margin-right:10px;">
           <asp:ImageButton ID="btnCancel" ImageUrl="~/assets/images/Cerrar_Ventana.gif" width="20" height="20"  runat="server" />
            </div>
		</div>
        <div style="width:515px; padding:10px; font-family: Arial, Helvetica, sans-serif; font-size:12px;">
<div class="row">
    <div  class="col-lg-6">
    <div role="form">
    <div class="form-group">
        <label>Text Input</label>
        <input class="form-control">
        <p class="help-block">Example block-level help text here.</p>
    </div>

    <div class="form-group">
        <label>Text Input with Placeholder</label>
        <input class="form-control" placeholder="Enter text">
    </div>
     <div class="form-group">
        <label>IVA</label>
         <asp:DropDownList CssClass="form-control" ID="comboIva" runat="server">
         </asp:DropDownList>
     </div>
          <div class="form-group">
        <label>TIPO</label>
        <asp:DropDownList ID="comboTipoComprobante" CssClass="form-control" runat="server">
        </asp:DropDownList>
       
     </div>
     <div class="form-group input-group">
            <asp:Button ID="Button1" runat="server" Text="Button" cssclass="btn btn-default" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>  
     <asp:Label ID="Label1" runat="server"                 Text="Label"></asp:Label>  
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel> 
    </div>
    </div>
    </div>
    </div>
</div>
      </div>
</div>
  
  
 

</asp:Panel>	 

</asp:Content>

