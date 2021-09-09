<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="backup.aspx.vb" Inherits="administracion_backup" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Administracion" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header"> BackUp</h1>
<ol class="breadcrumb"> 
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Forms
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="btnHacerBackUp"  class="btn btn-primary"   runat="server" Text="Hacer BackUp" />
&nbsp;<br />
    <asp:GridView ID="GrillaBackUp"  AllowPaging="true" PageSize="10" runat="server" class="table table-bordered table-hover table-striped" >
    <EmptyDataTemplate>
    No hay backups registrados
    </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>

