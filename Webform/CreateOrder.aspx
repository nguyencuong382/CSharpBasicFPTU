<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateOrder.aspx.cs" Inherits="Webform.CreateOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Order</title>
    <style>
        .err {
            color: red;
        }

        .success {
            color: green;
        }
    </style>
</head>
<body>

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx">Home</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ViewCart.aspx">View Cart</asp:HyperLink>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/CreateOrder.aspx">Create Order</asp:HyperLink>
    <br>

    <form id="form1" runat="server">

        <div>

            <asp:CustomValidator ID="validCart" runat="server" 
                ErrorMessage="Cart is tempty" OnServerValidate="validCart_ServerValidate"
                CssClass ="err"
                ></asp:CustomValidator>

            <table>
                
                <tr>
                    <td>Customer</td>
                    <td><asp:DropDownList ID="dlCustomers" runat="server"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td>Order Date</td>
                    <td>
                        <asp:Label ID="txtRequiredDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Required Date</td>
                    <td>
                        <asp:CustomValidator ID="CustomValidator1" runat="server"
                            ErrorMessage="Oder Date must be greater than Today at least 3 days" 
                            OnServerValidate="CustomValidator"
                            CssClass="err"></asp:CustomValidator>

                       <%-- <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="calendar"
                            CotrolToCompare="txtRequiredDate"
                            Operator="GreaterThan"
                            ErrorMessage="Error!">                             
                            </asp:CompareValidator>--%>
                        <asp:Calendar ID="calendar" runat="server" SelectedDate="<%# DateTime.Today %>"></asp:Calendar>

                     </td>
                 </tr>
                 <tr>
                    <td>Address</td>
                    <td>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2"
                            runat="server"
                            ErrorMessage="Address cannot be empty"
                            ControlToValidate="txtAddress" CssClass="err"></asp:RequiredFieldValidator>
                        <br>
                        <asp:TextBox ID="txtAddress" runat="server" ControlToValidate="txtAddress"></asp:TextBox>
                    </td>

                 </tr>

                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
