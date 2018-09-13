<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Impostazioni.aspx.cs" Inherits="Guida_Web_RC.Impostazioni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<h1>Impostazioni</h1>
<div>
   <h2>Personalizzazione</h2>
    <br />
    Nome sito:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="ns" runat="server"></asp:TextBox><br />
    <h2>Sicurezza</h2>
    <br />
    Modifica la password dell&#39;account Admin (lascire vuoto per non modificarla):<br />
    <br />
    Nuova password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox><br />
    <br />
    Conferma password:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
    <h2>Database</h2> <br />
    Server:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <br />
    Database:&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />
    <br />
    Utente:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    <br />
    Password:&nbsp;
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" ForeColor="Red"> </asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Salva" OnClick="Button1_Click" />
    <br />
    <br />
    <a href="AdminDash.aspx">Gestione Contenuti</a>&nbsp; 
            <br />
            <br />
            <a href="../Accesso.aspx">Disconnettiti</a><br />
</div>
</asp:Content>
