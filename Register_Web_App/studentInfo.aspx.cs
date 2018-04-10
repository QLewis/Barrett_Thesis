using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Register_Web_App
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string info = PreviousPage.studentInfo();

            string[] elements = info.Split('\n');

            nameLabel.Text = elements[0];
            mealsLabel.Text = elements[2];
            mgLabel.Text = elements[3];
            guestLabel.Text = elements[4];

        }


    }
}