<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="bitacora.aspx.vb" Inherits="micuenta_bitacora" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Administracion" runat="server" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header"> Bitacora</h1>
<ol class="breadcrumb"> 
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Bitacora
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="filter-panel" class="filter-panel" style="height: auto;">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-inline" role="form">
                        <div class="form-group">
                            <label class="filter-col" style="margin-right:0;" for="pref-perpage">Login:</label>
                            <asp:DropDownList ID="comboUsuario" AppendDataBoundItems="true"  class="form-control" runat="server"></asp:DropDownList>                               
                        </div>
                        <div class="form-group">
                            <label class="filter-col" style="margin-right:0;" for="pref-orderby">Objeto:</label>
                            <asp:DropDownList ID="comboObjeto"  class="form-control" runat="server"></asp:DropDownList>                               
                        </div> 
                        <div class="form-group">
                            <label class="filter-col" style="margin-right:0;" for="pref-orderby">Objeto:</label> 
                            <asp:DropDownList ID="comboAccion"  class="form-control" runat="server"> </asp:DropDownList>                             
                        </div>
<%--                        <div class="form-group">    
                            <button type="submit" class="btn btn-default filter-col">
                                <span class="fa fa-file-pdf-o"></span> PDF
                            </button>  
                        </div>--%>	
                        </div>
                    <div class="form-inline" role="form">		
          <div class="form-group">
                <label for="dtp_input1" class="filter-col"  >Fecha Desde</label>
                <div class="input-group date form_date col-md-5" data-date="" data-date-format="dd/mm/yyyy" data-link-field="dtp_input1" data-link-format="yyyy-mm-dd">
                    <%--<input class="form-control" size="16" type="text" value="" readonly>--%>
                    <asp:TextBox  class="form-control" Width="100px" ID="tbFechaDesde" runat="server"></asp:TextBox>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
					<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
				<input type="hidden" id="dtp_input1" value="" /><br/>
            </div>
            <div class="form-group">
                <label for="dtp_input2" class="filter-col"  >Fecha Hasta</label>
                <div class="input-group date form_date col-md-5" data-date="" data-date-format="dd/mm/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                    <%--<input class="form-control" size="16" type="text" value="" readonly>--%>
                    <asp:TextBox  class="form-control" Width="100px" ID="tbFechaHasta" runat="server"></asp:TextBox>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
					<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
				<input type="hidden" id="dtp_input2" value="" /><br/>
            </div>
            <div class="form-group">  
                <asp:LinkButton ID="lnkBuscar" class="btn btn-primary"  runat="server"> <span class="glyphicon glyphicon-cog"></span> Busqueda</asp:LinkButton>
            </div>
                        
                    </div>
                </div>
            </div>
        </div>    
        
<asp:GridView ID="GrillaBitacora" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped"  runat="server">
<Columns>
    <asp:BoundField DataField="id" HeaderText="Id" />
    <asp:BoundField DataField="login" HeaderText="Login" />
    <asp:BoundField DataField="evento" HeaderText="Evento" />
    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
    <asp:TemplateField HeaderText="Objeto">
        <ItemTemplate>
            <asp:Label ID="lblObjeto" runat="server" Text=""></asp:Label>  
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Acción">
        <ItemTemplate>
            <asp:Label ID="lblAccion" runat="server" Text=""></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Es Error?">
        <ItemTemplate>
            <asp:CheckBox ID="chkError" Checked='<%#Eval("eserror") %>' runat="server" />  
        </ItemTemplate>      
    </asp:TemplateField>
</Columns>
</asp:GridView>
         <i>Página <%=GrillaBitacora.PageIndex + 1%> de <%=GrillaBitacora.PageCount%> </i>   
</asp:Content>

