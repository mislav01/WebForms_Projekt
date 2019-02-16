<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OsobaKontrola.ascx.cs" Inherits="WebFormsMislavBasic.OsobaKontrola" %>
<div class="myPerson" runat="server" id="mojDiv">
    <asp:HiddenField runat="server" ID="txtID" />
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Name:" Font-Bold="true"/>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control input-sm" />
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtName" Display="Dynamic" CssClass="myValidators" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" Text="Surname:" Font-Bold="true" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSurname" CssClass="form-control input-sm" />
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtSurname" Display="Dynamic" CssClass="myValidators" />
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlEmail" CssClass="form-control input-sm" DataValueField="IDEmail" DataTextField="Naziv"
                        OnSelectedIndexChanged="ddlEmail_SelectedIndexChanged" AutoPostBack="true" />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" Text="Email" Font-Bold="true" />
                </td>
                <td>
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control input-sm">
                        </asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton runat="server" CssClass="btn btn-default btn-sm" ID="btnUpdateEmail" OnClick="btnUpdateEmail_Click">
                            <span class="glyphicon glyphicon-save" style="color: #0094ff; "></span>
                            </asp:LinkButton>
                        </span>

                    </div>
                </td>
                <td>
                    <asp:RegularExpressionValidator runat="server" ID="revEmail" ErrorMessage="*" Display="Dynamic" CssClass="myValidators"
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ValidationGroup="groupOsoba" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" Text="Phone:" Font-Bold="true" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control input-sm" />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" Text="Password:" Font-Bold="true" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control input-sm"/>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="myValidators" ErrorMessage="*" ID="rfvPassword"
                        ControlToValidate="txtPassword" ValidationGroup="groupOsoba" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" Text="Status:" Font-Bold="true" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control input-sm" DataTextField="Naziv" DataValueField="IDStatus" />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" Text="City:" Font-Bold="true" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control input-sm" DataTextField="Naziv" DataValueField="IDGrad" />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnEdit" Text="Edit" CssClass="btn btn-primary btn-sm" ValidationGroup="groupOsoba" OnClick="btnEdit_Click" />
                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-warning btn-sm" ValidationGroup="groupOsoba" OnClick="btnDelete_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td colspan="3">
                    <asp:ValidationSummary runat="server" ID="vsUserControl" CssClass="myValidators" ValidationGroup="groupOsoba" Style="display: none;" />
                </td>
            </tr>
        </tbody>
    </table>
</div>
