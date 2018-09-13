<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vai a scheda.aspx.cs" Inherits="Guida_Web_RC.Vai_a_scheda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p>
    <br />
</p>
<p>
    Inserisci il numero della scheda che vuoi visionare...</p>
<p>
    Vai alla scheda...
    <asp:TextBox ID="TextBox1" runat="server" Width="40px"></asp:TextBox>
&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="vai" />
</p>

</asp:Content>
