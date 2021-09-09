<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Comentarios.aspx.vb" Inherits="carrito_Opinion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 

<%@ Register src="../controles/menuizquierda.ascx" tagname="menuizquierda" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
    <link href="../assets/css/estilos2.css" rel="Stylesheet" />
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:menuizquierda ID="menuizquierda1" runat="server" />       
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
   
    
<div class="page product-reviews-page">
    <h4 class="muted">Comente sobre</h4>
    <div class="page-title">
        <h2><asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label></h2>
    </div>


<div  class="write-review" id="review-form"> 
<legend class="title">Escriba su opinion</legend>

<div class="forms-box">

<div class="inputs">
    <label for="AddProductReview_Rating">Clasificación</label>
    <div class="input-box review-rating star-rating star-rating-large">
        <asp:RadioButton ID="RadioButton1" runat="server" />
        <asp:Label ID="Label1" AssociatedControlID="RadioButton1" runat="server" Text=""></asp:Label>
        <asp:RadioButton ID="RadioButton2" runat="server" />
        <asp:Label ID="Label2" AssociatedControlID="RadioButton2" runat="server" Text=""></asp:Label>
        <asp:RadioButton ID="RadioButton3" runat="server" />
        <asp:Label ID="Label3" AssociatedControlID="RadioButton3" runat="server" Text=""></asp:Label>
        <asp:RadioButton ID="RadioButton4" runat="server" />
        <asp:Label ID="Label4" AssociatedControlID="RadioButton4" runat="server" Text=""></asp:Label>
        <asp:RadioButton ID="RadioButton5" runat="server" />
        <asp:Label ID="Label5" AssociatedControlID="RadioButton5" runat="server" Text=""></asp:Label>
    </div>
</div>

<div class="row">
<div class="col-lg-6">
    <div class="form-group">
    <label for="AddProductReview_Title">Titulo de la revisión</label>
    <asp:TextBox ID="tbTitulo" class="form-control" runat="server"></asp:TextBox>
    </div>
 </div>
</div>

<div class="inputs">
    <label for="AddProductReview_ReviewText">Revisión del texto</label>
    <div class="input-box">
        <asp:TextBox ID="tbComentarioTexto" CssClass="review-text" runat="server" TextMode="MultiLine" Rows="2" Columns="20"></asp:TextBox>
    </div>
</div>

</div>

<div class="clearfix">
    <asp:LinkButton runat="server" ID="lnkAgregarComentario"  CssClass="btn btn-primary write-product-review-button" >
        <i class="fa fa-check"></i>Agregar comentario
    </asp:LinkButton>
</div>
           
</div> 

<%--Lista Comentarios--%>
<div class="block">
    <div class="block-title"><h3>Criticas presentes</h3></div>

<div class="block-body">
    <div class="product-review-list">
        <asp:DataList ID="GrillaComentarios" runat="server">
<ItemTemplate>
    <div class="product-review-item">
        <div class="review-title">
        <div class="rating"><div style="width: 100%"></div></div>
            <strong><asp:Label ID="lblTitulo" runat="server" Text='<%#Eval("titulo") %>'></asp:Label></strong>, <span class="muted"><small><asp:Label ID="lblFecha" runat="server" Text='<%#Eval("fecha") %>'></asp:Label></small></span>
        </div>
        <div class="review-author muted"> <strong>Por:</strong><asp:Label ID="lblPor" Text='<%#Eval("cliente.razon") %>' runat="server"></asp:Label> </div>
        <div class="review-text"> <asp:Label ID="lblDescripcion"  runat="server" Text='<%#Eval("descripcion") %>'></asp:Label></div>
        <div class="product-review-vote muted">
            <span>¿Fue util el comentario?</span>
            <asp:LinkButton CommandName="VotarPositivo" CommandArgument='<%#Eval("id") %>'  class="vote vote-yes" ID="lnkPositivo" runat="server">
                <i class="fa fa-thumbs-up"></i>
                <span class="vote-count" data-bind-to="TotalYes">
                <strong style="font-size:12px"><asp:Label ID="Label7" runat="server" Text='<%#Eval("positivo") %>' ></asp:Label></strong></span>
            </asp:LinkButton>
            <asp:LinkButton CommandName="VotarNegativo" CommandArgument='<%#Eval("id") %>' class="vote vote-no" ID="lnkNegativo" runat="server">
                <i class="fa fa-thumbs-down"></i>
                <span class="vote-count" data-bind-to="TotalNo">
                <strong style="font-size:12px"><asp:Label ID="Label6" runat="server" Text='<%#Eval("negativo") %>'></asp:Label></strong></span>
            </asp:LinkButton>
        </div>
    </div>           
</ItemTemplate>
</asp:DataList>
    </div>
</div>
</div>
        

<div class="container">
  <!-- Trigger the modal with a button -->
  <!-- Modal -->
<div class="modal fade" id="myModal" role="dialog">
<div class="modal-dialog">
<!-- Modal content-->
<div class="modal-content">
<div class="modal-header modal-header-primary">
    <button type="button" class="close" data-dismiss="modal">&times;</button>
    <h4 class="modal-title">Comentario Registrado </h4>
</div>
<div class="modal-body">
    <div class="row"> 
        <div class="col-lg-12">
            <div class="form-group">
                <label> Se insertó correctamente el comentario.</label> 
            </div> 
            <div class="form-group">
                <asp:Button ID="btnIngresar" class="btn btn-success" runat="server" Text="Volver" /> 
            </div>
        </div><%-- col--%>
    </div> <%-- row --%>
</div>
<div class="modal-footer">
     
</div>
</div>
</div>
</div>
  
</div>



</div>

     
</asp:Content>

