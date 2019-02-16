<%@ Page Title="Person list" Language="C#" EnableEventValidation="false"  MasterPageFile="~/Pocetna.Master" AutoEventWireup="true" CodeBehind="PrikazOsoba.aspx.cs" Inherits="WebFormsMislavBasic.PrikazOsoba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        tr > th {
            background-color: #333;
            color: white;
            font-size: 1em;
            font-weight: normal;
            height: 30px;
            padding-left: 5px;
        }
        td {
            padding-left: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">


<div class="panel-group" id="accordion">
    <div class="panel panel-default">
        <div class="panel-heading" role="tab">
            <h4 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordion" href="#gridViewContent">
                    Grid View
                </a>
            </h4>
        </div>
        <div id="gridViewContent" class="panel-collapse collapse in">
            <div class="panel-body">
                <div>
                    <asp:GridView runat="server" ID="gridViewOsobe" AutoGenerateColumns="false" OnRowEditing="gridOsobe_RowEditing" OnRowCancelingEdit="gridOsobe_RowCancelingEdit"
                        OnRowUpdating="gridOsobe_RowUpdating" Width="100%" CssClass="tablicaOsobe" CellPadding="4" CellSpacing="0" GridLines="Horizontal"
                        >
                        <Columns>
<%--                            <asp:TemplateField Visible="false">
                                <EditItemTemplate>
                                    <asp:HiddenField runat="server" Value='<%# Eval("IDOsoba") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="IDOsoba" Visible="false"/>
                            <asp:BoundField DataField="Ime" HeaderText="Name" ControlStyle-CssClass="form-control" ControlStyle-Width="120px" ItemStyle-Width="150px">
                            </asp:BoundField>
                            <asp:BoundField DataField="Prezime" HeaderText="Surname" ControlStyle-CssClass="form-control" ControlStyle-Width="120px" ItemStyle-Width="150px">
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="E-mail addresses">
                                <ItemTemplate>
                                    <asp:Repeater runat="server" DataSource='<%# Eval("Email") %>'>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" PostBackUrl='<%# $"mailto:{Eval("Naziv")}" %>' Text='<%# Eval("Naziv") %>' />
                                            <br />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Repeater runat="server" DataSource='<%# Eval("Email") %>'>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# Eval("Naziv") %>' CssClass="form-control" />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Telefon" HeaderText="Telephone" ControlStyle-CssClass="form-control" ControlStyle-Width="150px"
                                ItemStyle-Width="200px">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList runat="server" DataTextField="Naziv" DataValueField="IDStatus" Enabled="false"
                                        CssClass="form-control" Width="150px" DataSourceID="dataSourceStatus" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList runat="server" DataTextField="Naziv" DataValueField="IDStatus"
                                        CssClass="form-control" Width="150px" DataSourceID="dataSourceStatus" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField EditText="Edit" ShowEditButton="true" ControlStyle-Width="45px"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading" id="headingPrvi">
            <h4 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordion" href="#repeaterContent">
                    Repeater
                </a>
            </h4>
        </div>
        <div id="repeaterContent" class="panel-collapse collapse">
            <div class="panel-body">
                <asp:Repeater runat="server" ID="repeaterOsobe">
                    <HeaderTemplate>
                        <table class="table table-condensed table-hover">
                            <tr>
                                <th>
                                    <asp:Label runat="server" Text="Name"/>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="Surname"/>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="Email addresses"/>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="Telephone"/>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="Status"/>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="City"/>
                                </th>
                                <th></th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("Ime") %>' />
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("Prezime") %>' />
                            </td>
                            <td>
                                <asp:Repeater runat="server" DataSource='<%# Eval("Email") %>'>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" PostBackUrl='<%# $"mailto:{Eval("Naziv")}" %>' Text='<%# Eval("Naziv") %>' />
                                        <br />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("Telefon") %>' />
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("NazivStatus") %>' />
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# Eval("NazivGrad") %>' />
                            </td>
                            <td>
                                <asp:Button runat="server" Text="Edit" CssClass="btn btn-primary btn-sm" CommandName="Click" CommandArgument='<%# Eval("IDOsoba") %>'
                                    OnCommand="Clicked_Command"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>
    <asp:SqlDataSource ID="dataSourceStatus"
        SelectCommand="GetStatus"
        ConnectionString= "Server=.;Database=WebFormsBaza;Uid=sa;Pwd=SQL"
        runat="server" />
</asp:Content>
