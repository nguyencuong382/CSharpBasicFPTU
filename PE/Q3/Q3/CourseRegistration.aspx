<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseRegistration.aspx.cs" Inherits="Q3.CourseRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CourseRegistration</title>
    <style>
        .err {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Student ID: <asp:TextBox ID="txtStudentId" runat="server" Enabled="False" Text="SE0123456"></asp:TextBox></p>
            <p>
                Student Name: <asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name can not blamk"
                    ControlToValidate="txtStudentName" CssClass="err"></asp:RequiredFieldValidator>
            </p>
            
            <p>Sext:

                <asp:Panel ID="Panel1" runat="server">

            </asp:Panel>
                <asp:RadioButton ID="rdMale" runat="server"  Text="Male" GroupName="gender" Checked="true"/>
                <asp:RadioButton ID="rdFemale" runat="server"  Text="Female" GroupName="gender"/>

            </p>
            <p> Subject:
                <asp:ListBox ID="lbSubject" runat="server"></asp:ListBox></p>

            <p>Time: <asp:DropDownList ID="dlTime" runat="server"></asp:DropDownList>

            </p>

            <p>Note:
            <asp:TextBox ID="txtNote" runat="server" Rows="5"></asp:TextBox></p>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
