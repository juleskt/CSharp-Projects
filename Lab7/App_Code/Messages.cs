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

public class Message
{
    public string Text;
    public int Id;
    public DateTime time;
    public string name;
    public Message()
    {
    }
}

/// <summary>
/// This class implements a ring buffer to store MAX messages
/// It is enumerable and can be used with the foreach statement
/// </summary>
public class Messages : IEnumerable
{
    public const int MAX = 5;   //max number of messages
    public Message[] buf;
    public int count = 0;
    public int first = 0;
    public int nextID = 1;
    public Messages()
    {
        buf = new Message[MAX];
    }
    public void Insert(string messageText, string name)
    {
        Message m = new Message();
        m.Text = messageText;
        m.Id = nextID++;
        m.time = DateTime.UtcNow;
        m.name=name;
        if (count == MAX)
        {
            buf[first] = m;
            first = (first + 1) % MAX;
        }
        else if (count == 0)
        {
            ++count;
            buf[first] = m;
        }
        else
        {
            buf[(first + count) % MAX] = m;
            ++count;
        }

    }
    public IEnumerator GetEnumerator()
    {
        for (int index = 0; index < count; ++index)
        {
            yield return buf[(first + index) % MAX];
        }
    }
}
