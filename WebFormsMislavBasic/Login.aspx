<%@ Page Title="Login" Language="C#" MasterPageFile="~/Pocetna.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsMislavBasic.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div>
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4">
                <div class="formContainer">
                    <div class="form-group">
                        <asp:label runat="server" text="E-mail" id="lblEmail" font-bold="true"/>

                        <asp:requiredfieldvalidator runat="server" errormessage="E-mail je obavezan." text="*"
                            controltovalidate="txtEmail" display="Dynamic" forecolor="Red">
                        </asp:requiredfieldvalidator>

                        <asp:regularexpressionvalidator runat="server" errormessage="Kriva E-mail adresa." text="*"
                            controltovalidate="txtEmail" display="Dynamic" validationexpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            forecolor="Red">
                        </asp:regularexpressionvalidator>

                        <br />

                        <asp:textbox runat="server" id="txtEmail" cssclass="form-control" />

                    </div>
                

                <div class="form-group">
                    <asp:Label Text="Lozinka:" ID="lblPassword" runat="server" Font-Bold="true" />

                    <asp:requiredfieldvalidator id="RequiredFieldValidatorPassword" runat="server" text="*"
                        errormessage="Lozinka je obavezna" controltovalidate="txtPassword" display="Dynamic" forecolor="Red">
                    </asp:requiredfieldvalidator>

                    <br />

                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" type="password" />
                </div>

                <div class="checkbox">                   
                    <asp:checkbox runat="server" id="cbZapamtiMe" Text="Zapamti me"></asp:checkbox>
                </div>

                <asp:button runat="server" text="Enter" id="btnlogin" CssClass="btn btn-primary" OnClick="btnlogin_Click"/>
                <div style="margin-top: 20px">
                    <asp:ValidationSummary id="validationSummaryLogin" runat="server" ForeColor="Red"/>
                </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
        </div>
    </div>
</asp:Content>
