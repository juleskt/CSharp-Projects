<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat.aspx.cs" Inherits="_Chat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AJAX Chat</title>

    <script type="text/javascript">
        var flag=false;
        function pageLoad()
        {
            var el=document.getElementById("message");
            if(flag==true)
            {
                el.value="";
                //Give focus to input box
                el.focus();
                flag=false;
            }
        }
        function clearInput()
        {
            flag=true;    
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <h1 style="text-align: center">
            AJAX Chat</h1>
        <br />
        &nbsp;Name:
        <asp:TextBox ID="name" runat="server" TabIndex="100"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="enter" runat="server" OnClick="enter_Click" Text="Enter" />
        &nbsp;
        <asp:Button ID="leave" runat="server" Enabled="False" OnClick="leave_Click" Text="Leave" />
        &nbsp;&nbsp;
        <asp:Label ID="error" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name"
            ErrorMessage="Name cannot be blank!"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                Users<br />
                <asp:ListBox ID="userBox" runat="server" Width="154px"></asp:ListBox>
                <br />
                <br />
                Viewers:
                <asp:Label ID="nusers" runat="server" Text="0"></asp:Label>
                <br />
                <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                    EnableViewState="False" Height="344px" ScrollBars="Both" Width="600px" Style="padding: 20px">
                    <asp:Label ID="content" runat="server" ReadOnly="True" TextMode="MultiLine" Rows="10"></asp:Label>
                </asp:Panel>
                <br />
                <asp:Button ID="send" runat="server" Text="Send" TabIndex="10" Height="26px" OnClick="send_Click"
                    OnClientClick="clearInput()" Enabled="False" />
                <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;&nbsp;
        <br />
        <asp:TextBox ID="message" runat="server" Height="94px" TextMode="MultiLine" Width="543px"
            TabIndex="1"></asp:TextBox>&nbsp;
        <br />
    </div>
    </form>
</body>
</html>
