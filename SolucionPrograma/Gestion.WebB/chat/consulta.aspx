<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="consulta.aspx.vb" Inherits="chat_consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 
    <br />


<div id="chat">

    <table>
    <tr> <td></td><asp:TextBox ID="tbMensaje" runat="server"></asp:TextBox><td><asp:Button ID="btnEnviarMensaje" runat="server" Text="Enviar Mensaje" /></td> </tr>
     </table>
    <div id="Layer1" style="width:500px; height:115px; overflow: scroll;">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
  
    <asp:Timer ID="Timer1" runat="server" Interval="1000">
    </asp:Timer>
   
        
        <asp:Label ID="lblChat" runat="server"></asp:Label>
    </ContentTemplate>
    <Triggers>
     <asp:AsyncPostBackTrigger ControlID="Timer1"  EventName="Tick" />
    </Triggers>
    </asp:UpdatePanel>
  
</div>

</div>
</asp:Content>

