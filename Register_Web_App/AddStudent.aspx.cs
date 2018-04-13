using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Register_Web_App.Models;
using System.Xml.Linq;

namespace Register_Web_App.Account
{
    public partial class Register : Page
    {
        string xmlPath = @"App_Data\Students.xml";

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (UserName.Text.Length != 6)
            {
                errorLabel.Text = "ERROR -- invalid id number";
            }
            else if (barrettButtonList.SelectedItem == null)
            {
                errorLabel.Text = "ERROR -- Is student in Barrett?";
            }
            else
            {
                if (inXML(UserName.Text))
                {
                    //doc.Add(newElement);

                    errorLabel.Text = "ERROR -- ID already exists";
                }
                else
                {
                    addElement();
                    errorLabel.Text = "The student was added to the XML file";

                }
                
            }
            /*var path = Server.MapPath(xmlPath);

            XDocument doc = XDocument.Load(path);*/    
        }

        //Search for ID to make sure it's not already there
        protected Boolean inXML(string inputText)
        {
            //Load in the XML File
            var path = Server.MapPath(xmlPath);

            XDocument doc = XDocument.Load(path);

            Boolean found = false;

            foreach (XElement element in doc.Descendants("Student"))
            {
                if (element.Element("ID").Value == inputText) //The student has been found
                {
                    found = true; 
                }
            }

            return found;
        }

        protected void addElement()
        {
            //Load in the XML File
            var path = Server.MapPath(xmlPath);

            XDocument doc = XDocument.Load(path);

            XElement studElement = new XElement("Student",
                                    new XAttribute("Barrett", barrettButtonList.SelectedItem.ToString()),
                                    new XElement("Name",
                                        new XElement("First", firstBox.Text),
                                        new XElement("Last", lastBox.Text)),
                                    new XElement("ID", UserName.Text),
                                    new XElement("Meals", "12"),
                                    new XElement("MGDollars", "45"),
                                    new XElement("GuestPasses", "10"));

            doc.Root.Add(studElement);

            doc.Save(path);
        }

        protected void regButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}