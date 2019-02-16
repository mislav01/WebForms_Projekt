<%@ Page Title="Add new person" Language="C#" MasterPageFile="~/Pocetna.Master" AutoEventWireup="true" CodeBehind="DodavanjeOsoba.aspx.cs" Inherits="WebFormsMislavBasic.DodavanjeOsoba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="formContainer">
        <div class="col-lg-4 col-md-4 col-sm-4">
            <div class="form-group">
                <asp:Label ID="lblName" runat="server" Text="Name:" Font-Bold="true"/>
                &nbsp;
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is required." ControlToValidate="txtName" 
                    CssClass="myValidators" Display="Dynamic" Text="*" ValidationGroup="groupAddPerson"/>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"/>
            </div>

            <div class="form-group">
                <asp:Label ID="lblSurname" runat="server" Text="Surname:" Font-Bold="true" />
                &nbsp;
                <asp:RequiredFieldValidator ID="rfvSurname" runat="server" ErrorMessage="Surname is required." ControlToValidate="txtSurname"
                    CssClass="myValidators" Display="Dynamic" Text="*" ValidationGroup="groupAddPerson" />
                <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true" />
                &nbsp;
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email is required." ControlToValidate="txtEmail"
                    CssClass="myValidators" Display="Dynamic" Text="*" ValidationGroup="groupAddPerson" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Wrong E-mail address." Text="*" ControlToValidate="txtEmail"
                    CssClass="myValidators" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:TextBox ID="txtEmail1" runat="server" CssClass="form-control"/>
                <asp:TextBox ID="txtEmail2" runat="server" CssClass="form-control" />
                <asp:LinkButton ID="btnAddEmail" runat="server" Text="Add more email addresses ..." OnClick="btnAddEmail_Click" OnClientClick="ShowElement" CausesValidation="false"/>
            </div>
        </div>

        <div class="col-lg-4 col-md-4 col-sm-4">
            <div class="form-group">
                <asp:Label ID="lblTelephone" runat="server" Text="Telephone:" Font-Bold="true" />
                &nbsp;
                <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblCity" runat="server" Text="City:" Font-Bold="true" />
                &nbsp;
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control input-sm" DataTextField="Naziv" DataValueField="IDGrad" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblStatus" runat="server" Text="Status:" Font-Bold="true" />
                &nbsp;
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control input-sm" DataTextField="Naziv" DataValueField="IDStatus" />
            </div>
        </div>

        <div class="col-lg-4 col-md-4 col-sm-4">
            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" Text="Password:" Font-Bold="true"/>
                &nbsp;
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required." ControlToValidate="txtPassword"
                    CssClass="myValidators" Display="Dynamic" Text="*" ValidationGroup="groupAddPerson" />
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" type="password"/>
            </div>
            <div class="form-group">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm password:" Font-Bold="true" />
                &nbsp;
                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Password confirmation is required." ControlToValidate="txtConfirmPassword"
                    CssClass="myValidators" Display="Dynamic" Text="*" ValidationGroup="groupAddPerson" />
                <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Wrong password confirmation." Text="*" Display="Dynamic"
                    CssClass="myValidators" ControlToValidate="txtPassword" ControlToCompare="txtConfirmPassword" ValidationGroup="groupAddPerson" />
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" type="password" />
            </div>
            <asp:Button ID="btnAdd" Text="Add" ValidationGroup="groupAddPerson" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
        </div>

        <div class="col-lg-12 col-md-12 col-sm-12">
            <div class="validationSummary">
                <asp:ValidationSummary runat="server" ForeColor="Red" ValidationGroup="groupAddPerson"/>
            </div>
        </div>
    </div>
    <div style="clear:both;"></div>
</asp:Content>
