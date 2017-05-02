using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getButton.Click += new EventHandler(this.getClicked);
    }

    void getClicked(Object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        DateTime localDate = DateTime.Now;

        String date = localDate.ToString("M/dd/yyyy");
        String time = localDate.ToString("h:mm tt");

        dateBox.Text = date;
        timeBox.Text = time;
    }
}