<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="Webform.ViewCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/default.aspx">Home</asp:HyperLink>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/ViewCart.aspx">View Cart</asp:HyperLink>
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/CreateOrder.aspx">Create Order</asp:HyperLink>
    <br>


    <form id="ViewCart" runat="server">
        <div>
            <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" AutoPostBack="true" OnRowCommand="CellClicked" EmptyDataText="No records Found">
                <Columns>
                   <asp:BoundField DataField="Product.ProductID" HeaderText="ID"/>
                   <asp:BoundField DataField="Product.ProductName" HeaderText="Product Name" />
                   <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price" />
                    <asp:BoundField DataField="Quality" HeaderText="Quality" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="+" runat="server" CommandArgument='<%# Eval("Product.ProductID")%>' CommandName="Inc"/>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="-" runat="server" CommandArgument='<%# Eval("Product.ProductID")%>' CommandName="Dec"/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="x" runat="server" CommandArgument='<%# Eval("Product.ProductID")%>' CommandName="Del" OnClientClick="return confirm('Are you sure you want to do this thing?');"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
