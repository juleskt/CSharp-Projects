<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Get Date Time
    </title>

    <style type="text/css">
        .center {
            text-align: center;
        }        .maindiv {
            margin: auto;
            border-style: solid;
            border-width: 1px;
            width: 800px;
            background-color: #C0C0C0;
            padding: 30px;
        }    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="maindiv">
        <h1 class="center">            Date and Time
        </h1>
        Date: <asp:TextBox runat="server" ID="dateBox" ReadOnly="True" />  Time:  <asp:TextBox runat="server" ID="timeBox" ReadOnly="True" />
        <br />
        <br />

        <asp:Button runat="server" ID="getButton" style="width:67px;" Text="Get" OnClientClick="getClicked" />

        <br />
        <br />

    </div>
    </form>
</body>
</html>
