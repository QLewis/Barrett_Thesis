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
            if (staffOrStudentList.SelectedItem.ToString() == "Staff")
            {
                //Check that ID is in Employee.xml
                Response.Redirect("Register.aspx");
            }
            else if (staffOrStudentList.SelectedItem.ToString() == "Student")
            {
                //Check that ID is in Student.xml
                /*string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Students.xml");
                XmlTextReader reader = null;
                try
                {
                    reader = new XmlTextReader(fileLocation);
                    reader.WhitespaceHandling = WhitespaceHandling.None;

                    reader.ReadStartElement("Students");
                    reader.Read();
                    //testLabel.Text = reader.LocalName; //Student
                    testLabel.Text = reader.ReadElementString("ID");
                }
                catch(Exception error)
                {
                    Console.Write(error.Message);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }*/
                //Response.Redirect("studentInfo.aspx");
                string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Students.xml");
                XPathDocument dx = new XPathDocument(fileLocation);
                XPathNavigator nav = dx.CreateNavigator();
                XPathNodeIterator iterator = nav.Select("/Students/Student");
                iterator.MoveNext(); //Gets student Node
                XPathNodeIterator it = iterator.Current.Select("ID"); //iterator within an iterator
                it.MoveNext(); //gets ID
                testLabel.Text = it.Current.Value;
                string idNumber = it.Current.Value;

                if (UserName.Text == idNumber)
                {
                    Response.Redirect("studentInfo.aspx");
                }


                
            }
        }
    }

    
}