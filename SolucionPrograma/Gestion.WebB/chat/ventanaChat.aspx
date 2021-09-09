<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ventanaChat.aspx.vb" Inherits="chat_ventanaChat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">  
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


<div id="chat">

    <table>
    <tr> <td></td><asp:TextBox ID="tbMensaje" runat="server"></asp:TextBox><td><asp:Button ID="btnEnviarMensaje" runat="server" Text="Enviar Mensaje" /></td> </tr>
     </table>
    <div id="Layer1" style="width:500px; height:115px; overflow: scroll; background-color:#ffffcc">
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

    </div>
    </form>
</body>
</html>
