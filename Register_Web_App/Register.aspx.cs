using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Register_Web_App
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Upon loading the page, load in the XML document and set it to ignore comments
            /*XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;

            XmlReader reader = XmlReader.Create("Students.xml", settings);

            XmlDocument doc = new XmlDocument();

            doc.Load(reader);*/
        }

        protected void enterButton_Click(object sender, EventArgs e)
        {
            if ((searchInput.Text != null) && (searchInput.Text.Length == 6))
            {
                errorLabel.Text = "Correct Input";
                //timeStamp();
            }
            else
            {
                //Display error message
                errorLabel.Text = "ERROR -- Invalid input";

                //Clear the input
                searchInput.Text = string.Empty;

                //Bring focus back to the textbox
                searchInput.Focus();
            }
        }

        //Uses time of day to determine the meal
        private void timeStamp()
        {
            TimeSpan breakfast = new TimeSpan(7, 30, 0); //7:30 am
            TimeSpan lunch = new TimeSpan(10, 30, 0); //10:30 am
            TimeSpan dinner = new TimeSpan(16, 0, 0); //4:00 pm

            DateTime currentTime = DateTime.Now;

            timeLabel.Text = currentTime.ToString("h:mm:ss tt");

            if ((currentTime.TimeOfDay >= breakfast) && (currentTime.TimeOfDay < lunch))
            {
                mealLabel.Text = "Breakfast";
            }
            else if ((currentTime.TimeOfDay >= lunch) && (currentTime.TimeOfDay < dinner))
            {
                mealLabel.Text = "Lunch";

            }
            else if (currentTime.TimeOfDay >= dinner)
            {
                mealLabel.Text = "Dinner";
            }
        }




        //TODO: Try to implement binarySearch algorithm


    }
}