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

        }

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
                        Response.Redirect("Register.aspx");
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
                        Response.Redirect("studentInfo.aspx");
                    }
                    count++;
                }
                if ((found == false) && (error == false))
                {
                    testLabel.Text = "ID Not Found";
                }

                
            }
        }
    }

    
}