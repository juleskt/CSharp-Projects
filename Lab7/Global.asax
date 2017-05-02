<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        Application["buffer"] = new Messages();
        Application["nusers"] = 0;
        Application["names"] = new Users();

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        int nusers = (int)Application["nusers"];
        ++nusers;
        Application["nusers"] = nusers;

    }

    void Session_End(object sender, EventArgs e) 
    {
        int nusers = (int)Application["nusers"];
        --nusers;
        Application["nusers"] = nusers;
        Users users = (Users)Application["names"];
        users.DeleteBySessionID(Session.SessionID);


    }
       
</script>
