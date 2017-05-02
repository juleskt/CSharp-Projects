using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users : IEnumerable
{
    private ArrayList users;
    public Users()
    {
        users = new ArrayList();
    }
    public void Add(string id, string name)
    {
        User u = new User(id, name);
        users.Add(u);
    }
    public IEnumerator GetEnumerator()
    {
        for (int index = 0; index < users.Count; ++index)
        {
            yield return users[index];
        }
    }

    public User GetUserByID(string id)
    {
        foreach (User u in users)
            if (u.sessionID == id)
                return u;
        return null;
    }

    public User GetUserByName(string name)
    {
        foreach (User u in users)
            if (u.name == name)
                return u;
        return null;
    }
    
    public void DeleteBySessionID(string id)
    {
        for (int i = 0; i < users.Count; ++i)
        {
            if (((User)users[i]).sessionID == id)
                users.RemoveAt(i);
        }
    }

}

public class User
{
    public string name;
    public string sessionID;
    public User(string id, string name)
    {
        this.name = name;
        this.sessionID = id;
    }
}
