<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDash.aspx.cs" Inherits="WebApplication3.Upload.Immagine.AdminDash" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="width:100%;">
        <div class="col-md-4" style="width:100%;">
            <%--<br />--%>
            <h1>Gestione contenuti</h1>
            <br />
            <h2>Schede audioguida</h2>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="Test1" OnRowDeleting="GridView3_RowDeleting" OnRowCommand="GridView3_OnRowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                    <asp:ButtonField CommandName="Delete" Text="Cancella" ButtonType="Button" />
                    <asp:ButtonField CommandName="getUrlS" Text="URL" ButtonType="Button" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="Test1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:Test1 %>" DeleteCommand="DELETE FROM [Schede] WHERE [Id] = @original_Id AND (([Nome] = @original_Nome) OR ([Nome] IS NULL AND @original_Nome IS NULL))" InsertCommand="INSERT INTO [Schede] ([Id], [Nome]) VALUES (@Id, @Nome)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [Id], [Nome] FROM [Schede]" UpdateCommand="UPDATE [Schede] SET [Nome] = @Nome WHERE [Id] = @original_Id AND (([Nome] = @original_Nome) OR ([Nome] IS NULL AND @original_Nome IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_Id" Type="Int32" />
                    <asp:Parameter Name="original_Nome" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                    <asp:Parameter Name="Nome" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nome" Type="String" />
                    <asp:Parameter Name="original_Id" Type="Int32" />
                    <asp:Parameter Name="original_Nome" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />

            <asp:TextBox ID="Id" runat="server" Width="55px" ForeColor="Black">ID</asp:TextBox>&nbsp;
            <asp:TextBox ID="Nome" runat="server" Width="346px" ForeColor="Black">Titolo</asp:TextBox> <br /> <br />
            <asp:TextBox ID="Descrizione" runat="server" Height="152px" Width="412px" AutoCompleteType="MiddleName" TextMode="Multiline" ForeColor="Black">Descrizione</asp:TextBox><br />
            <br />
            Immagine:&nbsp; <asp:DropDownList ID="Immagine" runat="server" ForeColor="#33CC33">
            </asp:DropDownList>
            <br />
            <br />
            Audio:&nbsp;
            <asp:DropDownList ID="Audio" runat="server" ForeColor="#33CC33">
            </asp:DropDownList>
&nbsp;<br />
            <br />
            <asp:Button ID="Upload" runat="server" Text="Aggiungi" OnClick="Upload_Click" />
            <br />
            <h2>Pagine HTML</h2>
            <br />
            <asp:SqlDataSource ID="Test1H" runat="server" ConnectionString="<%$ ConnectionStrings:Test1 %>" DeleteCommand="DELETE FROM [PagineH] WHERE [Id] = @original_Id" InsertCommand="INSERT INTO [PagineH] ([Id]) VALUES (@Id)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [Id] FROM [PagineH]">
                <DeleteParameters>
                    <asp:Parameter Name="original_Id" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Id" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="Test1H" OnRowCommand="GridView4_OnRowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:ButtonField CommandName="Delete" Text="Cancella" ButtonType="Button" />
                    <asp:ButtonField ButtonType="Button" CommandName="getURL" Text="URL" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="URLs" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" ForeColor="Black">Titolo</asp:TextBox><br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="100%" Height="123px" TextMode="MultiLine" ValidateRequestMode="Disabled" ForeColor="Black">Codice HTML</asp:TextBox><br />
            <br />
            Hai già un file HTML con la pagina? Selezionalo con la casella sotto quindi clicca su apri.<br />
            <asp:FileUpload ID="FileUpload1" runat="server"/><br /><asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Apri" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Aggiungi" />
           <br />
             <asp:SqlDataSource ID="PagineH" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:Test1 %>" DeleteCommand="DELETE FROM [PagineH] WHERE [Id] = @original_Id" InsertCommand="INSERT INTO [PagineH] ([Id]) VALUES (@Id)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [Id] FROM [PagineH]">
                <DeleteParameters>
                    <asp:Parameter Name="original_Id" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Id" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource>
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <a href="Impostazioni.aspx"  >Configurazione</a>&nbsp; 
            <br />
            <br />
            <a href="../Accesso.aspx">Disconnettiti</a><br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>

</asp:Content>