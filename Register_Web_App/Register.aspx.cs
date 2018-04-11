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
            if ((searchInput.Text == null) || (searchInput.Text.Length != 6))
            {
                //searchXML(searchInput.Text);

                //Display error message
                errorLabel.Text = "ERROR -- Invalid input";
                nameLabel.Text = string.Empty;
                idLabel.Text = string.Empty;
                mealsLabel.Text = string.Empty;
                mgLabel.Text = string.Empty;
                guestPassLabel.Text = string.Empty;

                //Clear the input
                searchInput.Text = string.Empty;

                //Bring focus back to the textbox
                searchInput.Focus();
            }
            else
            {
                if (paymentList.SelectedItem == null) //should not happen, but just in case
                {
                    errorLabel.Text = "ERROR -- Pick a payment method";
                }
                else if (paymentList.SelectedItem.ToString() == "Meal") //should be the default selection
                {
                    searchXML(searchInput.Text);
                }
                else if (paymentList.SelectedItem.ToString() == "M&G")
                {
                    errorLabel.Text = "The user has chosen to pay with M&G";
                }
                else if (paymentList.SelectedItem.ToString() == "Guest Pass")
                {
                    errorLabel.Text = "The user has chosen to use a guest pass";
                }
                else if (paymentList.SelectedItem.ToString() == "Cash/Credit")
                {
                    errorLabel.Text = "The user has chosen to pay with cash or a credit card";
                }
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
                if (element.Element("ID").Value == inputText) //The student has been found
                {
                    //Set found to true
                    found = true;

                    //check if Barrett student or not
                    if(element.Attribute("Barrett").Value == "No")
                    {
                        barrettLabel.Text = "Not a Barrett student";
                    }

                    errorLabel.Text = string.Empty;

                    //verify student has meals left
                     if (hasMeals(Int32.Parse(element.Element("Meals").Value)))
                     {

                        int oldMeals = Int32.Parse(element.Element("Meals").Value);
                        int newMeals = oldMeals - 1;

                        string newMealStr = newMeals.ToString();

                        element.Element("Meals").Value = newMealStr;

                        doc.Save(path);

                        nameLabel.Text = "Name: " + element.Element("Name").Element("First").Value + " " + element.Element("Name").Element("Last").Value;
                        idLabel.Text = "ID: " + element.Element("ID").Value;
                        mealsLabel.Text = element.Element("Meals").Value + " meals left";
                        mgLabel.Text = element.Element("MGDollars").Value + " M&G remaining";
                        guestPassLabel.Text = element.Element("GuestPasses").Value + " guest passes remaining";
                     }
                     else
                     {
                        errorLabel.Text = "ERROR -- insufficient meals";

                        nameLabel.Text = "Name: " + element.Element("Name").Element("First").Value + " " + element.Element("Name").Element("Last").Value;
                        idLabel.Text = "ID: " + element.Element("ID").Value;
                        mealsLabel.Text = element.Element("Meals").Value + " meals left";
                        mgLabel.Text = element.Element("MGDollars").Value + " M&G remaining";
                        guestPassLabel.Text = element.Element("GuestPasses").Value + " guest passes remaining";
                    }

                    //Clear the search box and bring focus back to it
                    searchInput.Text = string.Empty;
                    searchInput.Focus();
                }
            }

            if (found == false)
            {
                //Display error message
                errorLabel.Text = "ERROR -- ID number not found";
                nameLabel.Text = string.Empty;
                idLabel.Text = string.Empty;
                mealsLabel.Text = string.Empty;
                mgLabel.Text = string.Empty;
                guestPassLabel.Text = string.Empty;

                //Clear the input
                searchInput.Text = string.Empty;

                //Bring focus back to the text box
                searchInput.Focus();
            }
        }

        protected Boolean hasMeals(int mealNumber)
        {
            if (mealNumber == 0)
            {
                return false;
            }

            return true;
        }
    }
}
