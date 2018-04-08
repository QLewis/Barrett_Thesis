using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Xml.Linq;

namespace Register_Web_App
{
    public partial class About : Page
    {
        string xmlPath = @"App_Data\Students.xml";

        protected void Page_Load(object sender, EventArgs e)
        {
            timeStamp();
        }

        protected void enterButton_Click(object sender, EventArgs e)
        {
            //Make sure input exists and is equal to 6 digits
            if ((searchInput.Text != null) && (searchInput.Text.Length == 6))
            {
                
                searchXML(searchInput.Text);
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
            TimeSpan close = new TimeSpan(20, 0, 0); //8:00 pm

            DateTime currentTime = DateTime.Now;

            timeLabel.Text = currentTime.ToString("h:mm:ss tt");
            
            if ((currentTime.TimeOfDay >= breakfast) && (currentTime.TimeOfDay < lunch))
            {
                mealTimeLabel.Text = "Breakfast";
            }
            else if ((currentTime.TimeOfDay >= lunch) && (currentTime.TimeOfDay < dinner))
            {
                mealTimeLabel.Text = "Lunch";

            }
            else if ((currentTime.TimeOfDay >= dinner) && (currentTime.TimeOfDay < close))
            {
                mealTimeLabel.Text = "Dinner";
            }
            else
            {
                mealTimeLabel.Text = "Closed";
            }
        }


        protected void searchXML(string inputText)
        {
            //Load in the XML File
            var path = Server.MapPath(xmlPath);

            XDocument doc = XDocument.Load(path);

            //Variables for searching
            Boolean found = false;
     
            /*string isBarrett;
            string firstname;
            string lastname;*/


            foreach (XElement element in doc.Descendants("Student"))
            {
                if (element.Element("ID").Value == inputText)
                {
                    //Set found to true
                    found = true;

                    nameLabel.Text = "Name: " + element.Element("Name").Element("First").Value + " " + element.Element("Name").Element("Last").Value;
                    idLabel.Text = "ID: " + element.Element("ID").Value;
                    mealsLabel.Text = "Meals left: " + element.Element("Meals").Value;
                    mgLabel.Text = "M and G left: " + element.Element("MGDollars").Value;
                    guestPassLabel.Text = "Guest Passes left: " + element.Element("GuestPasses").Value;

                    //Clear the search box and bring focus back to it
                    searchInput.Text = string.Empty;
                    searchInput.Focus();
                }
            }

            if (found == false)
            {
                //Display error message
                errorLabel.Text = "ERROR -- ID number not found";

                //Clear the input
                searchInput.Text = string.Empty;

                //Bring focus back to the text box
                searchInput.Focus();
            }
        }
    }
}
