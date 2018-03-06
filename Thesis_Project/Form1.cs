using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Thesis_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            //Load in the XML document and set it to ignore comments
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;

            XmlReader reader = XmlReader.Create("Students.xml", settings);

            XmlDocument doc = new XmlDocument();

            doc.Load(reader);

            //Have the listView start off as empty
            searchResults.Items.Clear();
            barrettLabel.Text = string.Empty;
            Boolean found = false;
            string idNumber;
            string isBarrett;
            DateTime currentTime;

            //TODO: Try to implement binarySearch algorithm


            //String we're searching for is not empty, and equal to 6 digits
            if ((searchInput.Text != null) && (searchInput.Text.Length == 6))
            {
                Console.WriteLine("The input is correct");

                foreach(XmlNode node in doc.DocumentElement)
                {
                    //Get the id number of the student
                    idNumber = node.ChildNodes[1].InnerText;
                    
                    //check if id number is what we're searching for
                    if (idNumber == searchInput.Text)
                    {
                        found = true;
                        Console.WriteLine("Student Found");
                        currentTime = DateTime.Now;

                        
                        TimeSpan breakfast = new TimeSpan(7,30,0); //7:30 am
                        TimeSpan lunch = new TimeSpan(10, 30, 0); //10:30 am
                        TimeSpan dinner = new TimeSpan(16, 0, 0); //4:00 pm

                        //Get student's information
                        string firstname = node.ChildNodes[0].ChildNodes[0].InnerText;
                        string lastname = node.ChildNodes[0].ChildNodes[1].InnerText;

                        //Print results to listView
                        searchResults.Items.Add("Name: " + firstname + " " + lastname);
                        isBarrett = node.Attributes[0].InnerText;
                        if (isBarrett == "No")
                        {
                            barrettLabel.Text = "Not a Barrett Student -- charge extra";
                        }

                        //Convert number of meals from string to int
                        int mealCount = Int32.Parse(node.ChildNodes[2].InnerText) - 1;
                        node.ChildNodes[2].InnerText = mealCount.ToString();

                        searchResults.Items.Add("Barrett: " + node.Attributes[0].InnerText);
                        searchResults.Items.Add("Current Meals: " + node.ChildNodes[2].InnerText);
                        //searchResults.Items.Add("New Meal Count: " + (test - 1));
                        searchResults.Items.Add("Current M&G Amount: " + node.ChildNodes[3].InnerText);
                        searchResults.Items.Add("Current Guest Pass Amount: " + node.ChildNodes[4].InnerText);


                        //Use TimeSpan to determine what meal this is
                        timeLabel.Text = currentTime.ToString("h:mm:ss tt");

                        if ( (currentTime.TimeOfDay >= breakfast) && (currentTime.TimeOfDay < lunch))
                        {
                            mealLabel.Text = "Breakfast";
                        }
                        else if ( (currentTime.TimeOfDay >= lunch) && (currentTime.TimeOfDay < dinner))
                        {
                            mealLabel.Text = "Lunch";

                        }
                        else if (currentTime.TimeOfDay >= dinner)
                        {
                            mealLabel.Text = "Dinner";
                        }
                    }
                }
                //If not found, clear the textbox and display error message
                if (found == false)
                {
                    //Display error message
                    MessageBox.Show("ERROR -- ID number not found");

                    //Clear the input
                    searchInput.Text = string.Empty;
                    
                    //Bring focus back to the text box
                    searchInput.Focus();
                }
            }
            else
            {
                //Display error message
                MessageBox.Show("Invalid Input");

                //Clear the input
                searchInput.Text = string.Empty;

                //Bring focus back to the textbox
                searchInput.Focus();
            }
        }

        //TODO: Create a timestamp function in order to clean up your code
    }
}
