using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class _Chat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetContent();
        }
    }

    private void GetContent()
    {
        StringBuilder sb = new StringBuilder();

        try
        {
            foreach (Message m in (Messages)Application["buffer"])
            {
                sb.Append(m.name);
                sb.Append(": ");
                sb.Append(m.time.ToString());
                sb.AppendLine(" UTC<br />");
                sb.AppendLine(m.Text + "<br />");
            }

            content.Text = sb.ToString();
            userBox.Items.Clear();
            Users us = (Users)Application["names"];
            foreach (User u in us)
                userBox.Items.Add(u.name);
            nusers.Text = Application["nusers"].ToString();
        }
        catch (Exception e)
        {

        }
    }

    protected void send_Click(object sender, EventArgs e)
    {
        string mText = message.Text;
        if (mText != "")
        {
            mText = mText.Replace("\r\n", "<br />");
            if (name.Text != "")
                ((Messages)Application["buffer"]).Insert(mText, name.Text);
        }
        GetContent();

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        GetContent();
    }

    protected void enter_Click(object sender, EventArgs e)
    {
        Users users = (Users)Application["names"];
        if (users.GetUserByName(name.Text) != null)
        {
            error.Text = "NAME IN USE!";
            return;
        }
        error.Text = "";
        users.Add(Session.SessionID, name.Text);
        enter.Enabled = false;
        leave.Enabled = true;
        send.Enabled = true;
        name.Enabled = false;
        RequiredFieldValidator1.Enabled = false;
        GetContent();

    }
    protected void leave_Click(object sender, EventArgs e)
    {
        Users users = (Users)Application["names"];
        users.DeleteBySessionID(Session.SessionID);
        leave.Enabled = false;
        enter.Enabled = true;
        send.Enabled = false;
        name.Enabled = true;
        RequiredFieldValidator1.Enabled = true;
        GetContent();

    }
}