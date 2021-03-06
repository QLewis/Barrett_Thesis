﻿using System;
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

        public string globalID;

        protected void Page_Load(object sender, EventArgs e)
        {
            timeStamp();

            addButton.Visible = false;

            barrettLabel.Text = string.Empty;
        }

        protected void enterButton_Click(object sender, EventArgs e)
        {
            //Make sure input exists and is equal to 6 digits
            if ((searchInput.Text == null) || (searchInput.Text.Length != 6))
            {
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
                    searchXMLMeals(searchInput.Text);
                }
                else if (paymentList.SelectedItem.ToString() == "M&G")
                {
                    errorLabel.Text = "The user has chosen to pay with M&G";
                    searchXMLMG(searchInput.Text);
                }
                else if (paymentList.SelectedItem.ToString() == "Guest Pass")
                {
                    errorLabel.Text = "The user has chosen to use a guest pass";
                    searchXMLGP(searchInput.Text);
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


        protected void searchXMLMeals(string inputText)
        {
            //Load in the XML File
            var path = Server.MapPath(xmlPath);

            XDocument doc = XDocument.Load(path);

            //Variables for searching
            Boolean found = false;

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
                     if (hasMeals(Int32.Parse(element.Element("Meals").Value)) && paymentList.SelectedItem.ToString() == "Meal")
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

                globalID = searchInput.Text;

                addButton.Visible = true;
                //Clear the input
                //searchInput.Text = string.Empty;

                //Bring focus back to the text box
                searchInput.Focus();
            }
        }

        protected void searchXMLMG(string inputText)
        {
            //Load in the XML File
            var path = Server.MapPath(xmlPath);

            XDocument doc = XDocument.Load(path);

            //Variables for searching
            Boolean found = false;

            foreach (XElement element in doc.Descendants("Student"))
            {
                if (element.Element("ID").Value == inputText) //The student has been found
                {
                    //Set found to true
                    found = true;

                    //check if Barrett student or not
                    if (element.Attribute("Barrett").Value == "No")
                    {
                        barrettLabel.Text = "Not a Barrett student";
                    }

                    errorLabel.Text = string.Empty;

                    //verify student has meals left
                    if (hasMG(Int32.Parse(element.Element("MGDollars").Value)))
                    {

                        int oldMG = Int32.Parse(element.Element("MGDollars").Value);
                        int newMG = oldMG - 1;

                        string newMGStr = newMG.ToString();

                        element.Element("MGDollars").Value = newMGStr;

                        doc.Save(path);

                        nameLabel.Text = "Name: " + element.Element("Name").Element("First").Value + " " + element.Element("Name").Element("Last").Value;
                        idLabel.Text = "ID: " + element.Element("ID").Value;
                        mealsLabel.Text = element.Element("Meals").Value + " meals left";
                        mgLabel.Text = element.Element("MGDollars").Value + " M&G remaining";
                        guestPassLabel.Text = element.Element("GuestPasses").Value + " guest passes remaining";
                    }
                    else
                    {
                        errorLabel.Text = "ERROR -- insufficient M&G";

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

                globalID = searchInput.Text;

                addButton.Visible = true;

                //Clear the input
                searchInput.Text = string.Empty;

                //Bring focus back to the text box
                searchInput.Focus();
            }
        }

        protected void searchXMLGP(string inputText)
        {
            //Load in the XML File
            var path = Server.MapPath(xmlPath);

            XDocument doc = XDocument.Load(path);

            //Variables for searching
            Boolean found = false;

            foreach (XElement element in doc.Descendants("Student"))
            {
                if (element.Element("ID").Value == inputText) //The student has been found
                {
                    //Set found to true
                    found = true;

                    //check if Barrett student or not
                    if (element.Attribute("Barrett").Value == "No")
                    {
                        barrettLabel.Text = "Not a Barrett student";
                    }

                    errorLabel.Text = string.Empty;

                    //verify student has meals left
                    if (hasGP(Int32.Parse(element.Element("GuestPasses").Value)))
                    {

                        int oldGP = Int32.Parse(element.Element("GuestPasses").Value);
                        int newGP = oldGP - 1;

                        string newGPStr = newGP.ToString();

                        element.Element("GuestPasses").Value = newGPStr;

                        doc.Save(path);

                        nameLabel.Text = "Name: " + element.Element("Name").Element("First").Value + " " + element.Element("Name").Element("Last").Value;
                        idLabel.Text = "ID: " + element.Element("ID").Value;
                        mealsLabel.Text = element.Element("Meals").Value + " meals left";
                        mgLabel.Text = element.Element("MGDollars").Value + " M&G remaining";
                        guestPassLabel.Text = element.Element("GuestPasses").Value + " guest passes remaining";
                    }
                    else
                    {
                        errorLabel.Text = "ERROR -- insufficient guest passes";

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

                globalID = searchInput.Text;

                addButton.Visible = true;

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

        protected Boolean hasMG(int mgNumber)
        {
            if (mgNumber == 0)
            {
                return false;
            }

            return true;
        }

        protected Boolean hasGP(int gpNumber)
        {
            if (gpNumber == 0)
            {
                return false;
            }

            return true;
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            //Server.Transfer("AddStudent.aspx");
            Response.Redirect("AddStudent.aspx");
        }

        protected void removeButton_Click(object sender, EventArgs e)
        {
            string id = searchInput.Text;

            //Load in the XML File
            var path = Server.MapPath(xmlPath);

            XDocument doc = XDocument.Load(path);

            doc.Descendants("Student")
                .Where(x => (string)x.Element("ID") == id)
                .Remove();

            doc.Save(path);

            nameLabel.Text = string.Empty;
            idLabel.Text = string.Empty;
            mealsLabel.Text = string.Empty;
            mgLabel.Text = string.Empty;
            guestPassLabel.Text = string.Empty;


            errorLabel.Text = "The student has been removed form the database";
        }
    }
}
