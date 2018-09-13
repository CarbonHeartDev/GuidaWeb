<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accesso.aspx.cs" Inherits="Guida_Web_RC.Accesso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br /><br />
        <div>
            Inserire le credenziali per effettuare l'accesso:<br />
&nbsp;<br />
            Nome utente:&nbsp;
            <asp:DropDownList BackColor="Black" ID="DropDownList1" runat="server" Width="143px">
                <asp:ListItem>Admin</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp; Password:&nbsp;     <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Width="143px" BackColor="Black" ForeColor="White"></asp:TextBox><br />
            <br /><asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
            <br /><br /><asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
