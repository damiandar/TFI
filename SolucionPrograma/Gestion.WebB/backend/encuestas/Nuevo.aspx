<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Nuevo.aspx.vb" Inherits="backend_encuestas_Nuevo" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
    <h1 class="page-header">
        Encuestas
    </h1>
    <ol class="breadcrumb">
        <li>
            <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
        </li>
        <li class="active">
            <i class="fa fa-edit"></i> <a href="default.aspx">Encuestas</a>
        </li>
    </ol>  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-info">
        <div class="panel-heading">
        Nueva encuesta
        </div> 
        <div class="panel-body">     
        <div class="form-inline" role="form">
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Nombre:</label>
                    <asp:TextBox ID="tbDescripcion" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 1:</label>
                    <asp:TextBox ID="TextBox1" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>                
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 2:</label>
                    <asp:TextBox ID="TextBox2" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
                            <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 3:</label>
                    <asp:TextBox ID="TextBox3" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 4:</label>
                    <asp:TextBox ID="TextBox4" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 5:</label>
                    <asp:TextBox ID="TextBox5" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 6:</label>
                    <asp:TextBox ID="TextBox6" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 7:</label>
                    <asp:TextBox ID="TextBox7" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 8:</label>
                    <asp:TextBox ID="TextBox8" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 9:</label>
                    <asp:TextBox ID="TextBox9" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Opcion 10:</label>
                    <asp:TextBox ID="TextBox10" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div>
            
            <!-- form group [search] --> 
<%--                <div class="form-group">
                    <label class="filter-col" for="tbFecha" >Fecha:</label>--%>
                    <asp:TextBox ID="tbFecha"  class="form-control" Visible="false"  runat="server"></asp:TextBox>
                <%--</div>--%>
 
                <div class="form-group">    
                    <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

