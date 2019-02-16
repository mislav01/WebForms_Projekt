<%@ Page Title="Setup" Language="C#" MasterPageFile="~/Pocetna.Master" AutoEventWireup="true" CodeBehind="Postavke.aspx.cs" Inherits="WebFormsMislavBasic.Postavke" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="content">
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4">
                <div class="form-group">
                    <asp:Label runat="server" text="Theme:" Font-Bold="true"/>
                    <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddlTheme" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--- choose ---" Selected="True" Value="znopra" />
                        <asp:ListItem Text="Default"  />
                        <asp:ListItem Text="Blue" />
                        <asp:ListItem Text="Red" />
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" Text="Language:" Font-Bold="true" />
                    <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddlLangChoose" OnSelectedIndexChanged="ddlLangChoose_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--- choose ---" Selected="True" Value="znopra" />
                        <asp:ListItem Text="Croatian" Value="hr" />
                        <asp:ListItem Text="English" Value="en" />
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" Text="Repozitorij:" Font-Bold="true" />
                    <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddlRepoChoose" OnSelectedIndexChanged="ddlRepoChoose_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--- choose ---" Selected="True" Value="znopra" />
                        <asp:ListItem Text="Tekstualna datoteka" Value="text" />
                        <asp:ListItem Text="Baza podatka" Value="baza" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </di>
</asp:Content>
