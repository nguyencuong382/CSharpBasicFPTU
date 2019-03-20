<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Webform._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>

    <style>
        td {
            vertical-align: top;
        }

        .active {
            color: green;
        }
    </style>
</head>
<body>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx">Home</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ViewCart.aspx">View Cart</asp:HyperLink>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/CreateOrder.aspx">Create Order</asp:HyperLink>
    <br>
    <form id="default" runat="server">
        <div>

            <table>
                <tr>
                <td>
                    <%--<asp:DropDownList ID="dlCategory" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="dlCategory_SelectedIndexChanged"></asp:DropDownList>--%>
                    <asp:DataList ID="dtCategory" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbCategory" runat="server" CommandArgument='<%# Eval("CategoryID")%>'  CommandName="CategoryID" OnClick="lbCategory_Click"><%# Eval("CategoryName")%></asp:LinkButton>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
                <td>
                    <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="false" OnRowCommand="gvProduct_SelectedIndexChanged" OnPageIndexChanging="PageIndexChanging" AllowPaging="True" EmptyDataText="No records Found">
                       <Columns>
                           <asp:BoundField DataField="ProductID" HeaderText="ID"/>
                           <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                           <asp:BoundField DataField="UnitPrice" HeaderText="Price" />
                           <asp:TemplateField ShowHeader="False">
                               <ItemTemplate>
                                   <asp:Button runat="server" HeaderText="Add to cart" Text="Add to cart" ButtonType="Button" CommandName="AddToCart" CommandArgument='<%# Eval("ProductID") %>'/>
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>
                    </asp:GridView>
                </td>
                </tr>
            </table>
            


        </div>
    </form>

</body>
</html>
