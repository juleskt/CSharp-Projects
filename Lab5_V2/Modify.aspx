<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modify.aspx.cs" Inherits="Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modify Database</title>
    <style>
        #errorText {
            color: darkred;
        }

        #successText {
            color: darkgreen;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div style="background-color: lightgray; border-style: solid; border-width: 1px; margin: auto; width: 800px; padding: 10px; text-align:center;">
        <h1 style="text-align: center">Modify Database</h1>

       <!-- <p style="float:left">Delete entry from DB:</p> -->

        <div style="text-align: center;">
            <p>Delete entry from DB:</p>
            <asp:DropDownList ID="inputUnit" runat="server" DataSourceID="SqlDataSource1" DataTextField="Unit" DataValueField="Id"></asp:DropDownList> 
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Conversions]"></asp:SqlDataSource>
            <asp:Button ID="delete" runat="server" Text="Delete" OnClick="delete_Click" />
        </div>

       <div style="text-align: center; margin-top: 10px;">
            <p>Add entry to DB:</p>
            <asp:TextBox ID="inputUnitText" runat="server" placeholder="Enter new unit"></asp:TextBox>
            <asp:TextBox ID="inputFactorText" runat="server" placeholder="Enter new factor"></asp:TextBox>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Conversions]"></asp:SqlDataSource>
            <asp:Button ID="add" runat="server" Text="Add" OnClick="add_Click" />
       </div>

       <div style="align-content: center; margin-top: 30px;">
           <asp:Button ID="backToConversions" runat="server" Text="Return to Conversions" OnClick="conversion_Click" />
       </div>

       <br /> 
       <br /> 
       <br /> 
       <br /> 

       <asp:Label ID="errorText" runat="server"></asp:Label> 
       <asp:Label ID="successText" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
