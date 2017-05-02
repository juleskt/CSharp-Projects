<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unit Conversion</title>
    <style>
        #errorText {
            color: darkred;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div style="background-color: lightgray; border-style: solid; border-width: 1px; margin: auto; width: 800px; padding: 10px; text-align:center;">
        <h1 style="text-align: center">Unit Conversion</h1>

       <div style="width:50%; float: left; text-align: left;">
           <p>From:</p>
           <asp:TextBox ID="inputText" runat="server"></asp:TextBox>
           <asp:DropDownList ID="inputUnit" runat="server" DataSourceID="SqlDataSource1" DataTextField="Unit" DataValueField="Factor"></asp:DropDownList> 
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Conversions]"></asp:SqlDataSource>
       </div>
       <div style="width:50%; float:right; text-align:right;">
           <p>To:</p>
           <asp:TextBox ID="outputText" runat="server" ReadOnly="True"></asp:TextBox>
           <asp:DropDownList ID="outputUnit" runat="server" DataSourceID="SqlDataSource2" DataTextField="Unit" DataValueField="Factor"></asp:DropDownList>
           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Conversions]"></asp:SqlDataSource>
       </div>
       <br /> 
       <br /> 
       <br /> 
       <br /> 
       <asp:Button ID="convert" runat="server" Text="Convert" OnClick="convert_Click" /> 
       <br /> 
       <br /> 
       <asp:Button ID="modify" runat="server" Text="Modify Database" OnClick="modify_Click"/> 
       <br /> 
       <br />   
       <asp:Label ID="errorText" runat="server"></asp:Label> 
    </div>
    </form>
</body>
</html>

