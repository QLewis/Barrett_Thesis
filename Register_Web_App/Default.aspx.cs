using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

namespace Register_Web_App
{
    public partial class _Default : Page
    {
        public string firstName;
        public string lastName;
        public string globalID;
        public string mealsLeft;
        public string mgDollars;
        public string guestPasses;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //TODO: make a searchStudent() and a searchStaff() method
        protected void logInButton_Click(object sender, EventArgs e)
        {
            Boolean found = false;
            Boolean error = false;
            string idNumber;
            int count = 0;

            if (staffOrStudentList.SelectedItem == null)
            {
                testLabel.Text = "ERROR -- Pick Staff or Student";
            }
            else if (staffOrStudentList.SelectedItem.ToString() == "Staff")
            {
                //Make sure input is correct length before opening the document
                if (UserName.Text.Length != 8)
                {
                    testLabel.Text = "ERROR -- Invalid input";
                    error = true;
                }

                string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Employees.xml");
                XPathDocument dx = new XPathDocument(fileLocation);
                XPathNavigator nav = dx.CreateNavigator();
                XPathNodeIterator iterator = nav.Select("/Employees/Employee");

                int nodeCount = iterator.Count; //Gets the number of nodes in the set

                while ((found == false) && (error == false) && (count <= nodeCount))
                {
                    iterator.MoveNext();
                    XPathNodeIterator it = iterator.Current.Select("ID");
                    it.MoveNext();
                    idNumber = it.Current.Value;

                    if (UserName.Text == idNumber)
                    {
                        found = true;

                        if (iterator.Current.GetAttribute("Cashier","").ToString() == "No")
                        {
                            error = true;
                            testLabel.Text = "ERROR -- not a cashier";
                        }
                        else
                        {
                            Response.Redirect("Register.aspx");
                        }
                        
                    }

                    count++;
                }
                //Get through searching and the id is not found
                if ((found == false) && (error == false))
                {
                    testLabel.Text = "ID not found";
                }
            }
            else if (staffOrStudentList.SelectedItem.ToString() == "Student")
            {
                //Make sure input is correct length before opening the document
                if (UserName.Text.Length != 6)
                {
                    testLabel.Text = "ERROR -- Invalid input";
                    error = true;
                }

                string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Students.xml");
                XPathDocument dx = new XPathDocument(fileLocation);
                XPathNavigator nav = dx.CreateNavigator();
                XPathNodeIterator iterator = nav.Select("/Students/Student"); //selects all Student elements that are children of students
                //iterator.MoveNext();

                int nodeCount = iterator.Count; //Gets the number of nodes in the set

                while((found == false) && (error == false) && (count <= nodeCount))
                {
                    iterator.MoveNext();
                    XPathNodeIterator it = iterator.Current.Select("ID");
                    it.MoveNext();
                    idNumber = it.Current.Value;
                    if (UserName.Text == idNumber)
                    {
                        found = true;

                        it = iterator.Current.Select("Name/First");
                        it.MoveNext();
                        firstName = it.Current.Value;

                        it = iterator.Current.Select("Name/Last");
                        it.MoveNext();
                        lastName = it.Current.Value;

                        globalID = idNumber;

                        it = iterator.Current.Select("Meals");
                        it.MoveNext();
                        mealsLeft = it.Current.Value;

                        it = iterator.Current.Select("MGDollars");
                        it.MoveNext();
                        mgDollars = it.Current.Value;

                        it = iterator.Current.Select("GuestPasses");
                        it.MoveNext();
                        guestPasses = it.Current.Value;

                        //testLabel.Text = studentInfo();

                        //Response.Redirect("studentInfo.aspx");
                        Server.Transfer("studentInfo.aspx");
                    }
                    count++;
                }
                if ((found == false) && (error == false))
                {
                    testLabel.Text = "ID Not Found";
                }

                
            }
        }

        //Public method to be accessed by targetPage
        public string studentInfo()
        {
            string info = firstName + " " + lastName + "\n " 
                          + globalID + "\n " 
                          + mealsLeft + "\n " 
                          + mgDollars + " \n" 
                          + guestPasses;
            return info;
        }

    }

    
}