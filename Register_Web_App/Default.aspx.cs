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
        protected void Page_Load(object sender, EventArgs e)
        {
            /*string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Students.xml");
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(fileLocation);
                reader.WhitespaceHandling = WhitespaceHandling.None;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }*/

            Console.WriteLine("The page_load function in default.aspx.cs");

        }

        protected void logInButton_Click(object sender, EventArgs e)
        {
            Boolean found = false;
            string idNumber;

            if (staffOrStudentList.SelectedItem.ToString() == "Staff")
            {
                string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Employees.xml");
                XPathDocument dx = new XPathDocument(fileLocation);
                XPathNavigator nav = dx.CreateNavigator();
                XPathNodeIterator iterator = nav.Select("/Employees/Employee");

                while (found == false)
                {
                    iterator.MoveNext();
                    XPathNodeIterator it = iterator.Current.Select("ID");
                    it.MoveNext();
                    idNumber = it.Current.Value;

                    if (UserName.Text == idNumber)
                    {
                        found = true;
                        Response.Redirect("Register.aspx");
                    }
                }
            }
            else if (staffOrStudentList.SelectedItem.ToString() == "Student")
            {
                string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Students.xml");
                XPathDocument dx = new XPathDocument(fileLocation);
                XPathNavigator nav = dx.CreateNavigator();
                XPathNodeIterator iterator = nav.Select("/Students/Student");
                /*
                iterator.MoveNext(); //Gets student Node
                XPathNodeIterator it = iterator.Current.Select("ID"); //iterator within an iterator
                it.MoveNext(); //gets ID
                string idNumber = it.Current.Value;

                if (UserName.Text == idNumber)
                {
                    Response.Redirect("studentInfo.aspx");
                }
                */
                while(found == false)
                {
                    iterator.MoveNext();
                    XPathNodeIterator it = iterator.Current.Select("ID");
                    it.MoveNext();
                    idNumber = it.Current.Value;

                    if (UserName.Text == idNumber)
                    {
                        found = true;
                        Response.Redirect("studentInfo.aspx");
                    }
                }
                if (found == false)
                {
                    testLabel.Text = "ID Not Found";
                }

                
            }
            else if (staffOrStudentList.SelectedItem.Equals(null))
            {
                testLabel.Text = "Must select radio button";
            }
        }
    }

    
}