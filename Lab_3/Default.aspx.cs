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
        if (IsPostBack)
        {
           Palindromes.Items.Clear();
        }
    }

    protected void generatePalindromes_Click(object sender, EventArgs e)
    {
        try
        {
            int startingNum = Convert.ToInt32(startNum.Text);
            int countNum = Convert.ToInt32(Count.Text);

            if (startNum.Text.Length == 0 || startingNum < 0 || startingNum > 1000000000)
            {
                userFeedback.Text = "Please enter a positive starting integer within the range.";
            }
            else if (Count.Text.Length == 0 || countNum < 1 || countNum > 100)
            {
                userFeedback.Text = "Please enter a positive count integer within the range.";
            }
            else
            {
                generateThePalindromes(startingNum, countNum);
                userFeedback.Text = "";
            }
        }
        catch (Exception ex)
        {
            userFeedback.Text = "Please enter a valid integer.";
        }
    }

    protected void generateThePalindromes(int start, int numPalindromes)
    {
        while (numPalindromes > 0 && start < int.MaxValue)
        {
            if (numIsPalindrome(start))
            {
                Palindromes.Items.Add(Convert.ToString(start));
                numPalindromes--;
            }

            start++;
        }
    }

    protected bool numIsPalindrome(int num)
    {
        string number = Convert.ToString(num);

        int leftIt = 0;
        int rightIt = number.Length - 1;

        while (leftIt < rightIt)
        {
            if (number[leftIt] != number[rightIt])
                return false;

            leftIt++;
            rightIt--;
        }

        return true;
    }
}