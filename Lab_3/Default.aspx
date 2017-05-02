<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Numeric Palindromes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: #C0C0C0; border-style: solid; border-width: 1px; margin: auto; width: 800px; padding: 10px">
            <h1 style="text-align: center">Find Numeric Palindromes</h1>
            <div style="text-align: center">
                Enter a starting integer (0-1,000,000,000):&nbsp;
            <asp:TextBox name="startNum" runat="server" ID="startNum" style="width:81px;" />
                &nbsp;&nbsp; Enter count (1-100):&nbsp;
            <asp:TextBox name="Count" runat="server" ID="Count" style="width:47px;" />
                <br />
                <br />
            <asp:Button ID="generatePalindromes" runat="server" Text="Generate" OnClick="generatePalindromes_Click"/>
                <br />
                <br />
            <asp:ListBox ID="Palindromes" runat="server" style="width:100px;" Rows="10"></asp:ListBox>
                <br />
                <br />
            <asp:Label ID="userFeedback" runat="server" Text=""></asp:Label>
            </div>
            <br />
        </div>

    </form>
</body>
</html>
