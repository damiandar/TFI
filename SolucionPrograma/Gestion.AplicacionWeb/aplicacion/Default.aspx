<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Tsu.Paginas.aplicacion_Default" title="::Bienvenida::" %>

<%--<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">

</asp:Content>--%>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
e=document.getElementById("columnaIzquierda");
e.style.display = 'none';
d=document.getElementById("tituloSeccion");
d.style.display='none';

</script>

     <div style="width:715px;  float:left;">
					<script type="text/javascript">
					e=document.getElementById("columnaIzquierda");
					e.style.display = 'none';
					d=document.getElementById("tituloSeccion");
					d.style.display='none';
					</script>
    <asp:ImageButton  ID="ImagenInicio" runat="server" />
<%--<input type="image" name="ctl00$ContentPlaceHolder1$ImagenInicio" id="ctl00_ContentPlaceHolder1_ImagenInicio" src="./Bienvenida  _files/inicio201301.jpg" onclick="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;ctl00$ContentPlaceHolder1$ImagenInicio&quot;, &quot;&quot;, false, &quot;&quot;, &quot;../micarga/folletos.aspx&quot;, false, false))" style="border-width:0px;">--%>
</div>
   
    <div style="width:925px;  float:left; margin-top:15px;">
       <div style="width:306px; float:left;">
            
            <asp:ImageButton ID="ImagenHome01" runat="server"  width="306" height="44" border="0" />
       
        </div>
        <div style="width:313px; float:left;"><span style="width:298px; float:left;">
      
           <asp:ImageButton ID="ImagenHome02" width="313" height="44" border="0"  runat="server" />
       </span>
        </div>
        <div style="width:306px; float:left;"><span style="width:298px; float:left;">
            
        <asp:ImageButton ID="ImagenHome03" runat="server"   width="306" height="44" border="0"/>
      </span>
        </div>
     </div>
    
</asp:Content>

