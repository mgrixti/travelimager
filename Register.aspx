<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<%--Register Page Markup--%>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="Server">
    <asp:Panel ID="Panel1" runat="server" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Register for a new account</h2>
                <hr />
            </div>
        </div>

        <%--Registration Area--%>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/login.aspx"
            CreateUserButtonStyle-CssClass="btn btn-primary" CreateUserButtonText="Register" CompleteSuccessText="Thanks for registering."
            OnCreatedUser="CreateUserWizard1_CreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" >
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:UpdatePanel ID="upRegister" runat="server">
                                    <ContentTemplate>
                                        <table class="input-table">

                                            <tr>
                                                <td>
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Text="User Name:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ForeColor="Red"
                                                        ErrorMessage="* User Name is required." ToolTip="* User Name is required." ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Password:"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ForeColor="Red"
                                                        ErrorMessage="* Password is required." ToolTip="* Password is required." ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword" Text="Confirm Password:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                                        ErrorMessage="* Confirm Password is required." ToolTip="Confirm Password is required." ForeColor="Red"
                                                        ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ForeColor="Red"
                                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="* The Password and Confirmation Password must match."
                                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email" Text="Email"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ForeColor="Red" Display="Dynamic"
                                                        ErrorMessage="* E-mail is required." ToolTip="* E-mail is required." ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" Display="Dynamic"
                                                        ControlToValidate="Email" ForeColor="Red" ErrorMessage="* Email must be in correct format example@example.com"
                                                        ValidationGroup="CreateUserWizard1"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question" Text="Security Question:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ForeColor="Red"
                                                        ErrorMessage="* Security question is required." ToolTip="Security question is required."
                                                        ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" Text="Answer:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ForeColor="Red"
                                                        ErrorMessage="* Security answer is required." ToolTip="Security answer is required."
                                                        ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </asp:Panel>
</asp:Content>
