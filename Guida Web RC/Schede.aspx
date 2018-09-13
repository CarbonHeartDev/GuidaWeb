<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schede.aspx.cs" Inherits="WebApplication3.VisualizzazioneUtente" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <h3><asp:Label ID="Nome" runat="server"></asp:Label></h3>
    <br />
    <br />
    <asp:Label ID="Descrizione" runat="server" Visible="False"></asp:Label> <br /> <br />
    <a href="null"><img src="null" id="Foto" runat="server" alt="" title="" class="img-responsive" visible="False"/></a><br /><br />
    <audio controls="controls" autoplay="autoplay" id="audioplayer" runat="server" visible="False">
            <source src="SeeU.mp3" type="audio/mpeg" />
            Your browser does not support the audio element.
        </audio><br /><br />&nbsp; 
    <a href="Vai%20a%20scheda.aspx">Vai a un'altra scheda</a>

</asp:Content>
