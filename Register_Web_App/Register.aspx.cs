using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Xml.XPath;

namespace Register_Web_App
{
    public partial class About : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Load up that XML document when the page loads
            //Upon loading the page, load in the XML document and set it to ignore comments
            /*FileStream fS = null;
            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Book.xml");
            try
            {
                if (File.Exists(fLocation))
                {
                    fS = new FileStream(fLocation, FileMode.Open, FileAccess.Read);
                    XmlDocument xd = new XmlDocument();
                    xd.Load(fS);
                    fS.Close();
                }
            }
            finally
            {
                fS.Close();
            }*/
          }

        protected void enterButton_Click(object sender, EventArgs e)
        {
            
            if ((searchInput.Text != null) && (searchInput.Text.Length == 6))
            {
                errorLabel.Text = "Correct Input";
                timeStamp();
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
                mealLabel.Text = "Breakfast";
            }
            else if ((currentTime.TimeOfDay >= lunch) && (currentTime.TimeOfDay < dinner))
            {
                mealLabel.Text = "Lunch";

            }
            else if ((currentTime.TimeOfDay >= dinner) && (currentTime.TimeOfDay < close))
            {
                mealLabel.Text = "Dinner";
            }
            else
            {
                mealLabel.Text = "Closed";
            }
        }


        //TODO: Try to implement binarySearch algorithm
        protected void searchXML(string inputText)
        {
            string idNumber;
            string isBarrett;
            string firstname;
            string lastname;
            Boolean found = false;
            int count = 0;

            string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Students.xml");
            XPathDocument dx = new XPathDocument(fileLocation);
            XPathNavigator nav = dx.CreateNavigator();
            XPathNodeIterator iterator = nav.Select("/Students/Student"); //selects all Student elements that are children of students

            int nodeCount = iterator.Count; //Gets the number of nodes in the set

            while ((found == false) && (count <= nodeCount))
            {
                iterator.MoveNext();
                XPathNodeIterator it = iterator.Current.Select("ID");
                it.MoveNext();
                idNumber = it.Current.Value;

                if (inputText == idNumber)
                {
                    found = true;
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
