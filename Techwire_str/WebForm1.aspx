<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Techwire_str.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 326px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>--%>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

            <asp:DropDownList ID="DropDownList1" DataTextField="CAR_NAME" DataValueField="CAR_ID" runat="server" Style="" Width="129px">
                <asp:ListItem Value="0">Select Model</asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />

            <input id="Date1" type="date" name="Date" runat="server" />

            <br />
            <br />

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        </div>

        <table id="example1" class="">
            <thead>
                <tr>
                    <th>User ID</th>
                    <th>User Name</th>
                    <th>Car Model</th>
                    <th>Date</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
            </thead>
            <tbody>

                <% =_str %>
            </tbody>
        </table>

    </form>

</body>
</html>
