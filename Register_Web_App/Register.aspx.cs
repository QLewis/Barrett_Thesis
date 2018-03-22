using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Register_Web_App
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Upon loading the page, load in the XML document and set it to ignore comments
            /*XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;

            XmlReader reader = XmlReader.Create("Students.xml", settings);

            XmlDocument doc = new XmlDocument();

            doc.Load(reader);*/
        }

        /*private void enterButton_Click(object sender, EventArgs e)
        {
            searchResults.Items.Clear();
            barretLabel.Text = string.Empty;
            Boolean found = false;
            string idNumber;
            string isBarrett;
            DateTime currentTime;

            //String we're searching for is not empty, and equal to 6 digits
            if ((searc))
        }*/
        //TODO: Try to implement binarySearch algorithm

    
    }
}