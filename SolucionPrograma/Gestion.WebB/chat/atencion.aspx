<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="atencion.aspx.vb" Inherits="chat_atencion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DropDownList ID="comboConectados" runat="server">
    </asp:DropDownList>   
    <asp:Button ID="btnChatear" runat="server" Text="Chatear" />
</asp:Content>

