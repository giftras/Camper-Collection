using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace projectITE233
{
	public partial class AddActivities : Form
	{
		public AddActivities()
		{
			InitializeComponent();
		}

		private void AddActivities_Load(object sender, EventArgs e)
		{
			//called LoadXML()
            LoadXml();

			
		}
        private void LoadXml()
        {
            //Load document
            XDocument xdoc = XDocument.Load("../../activities.xml");
            // read activity where the item in that date
            var xdocRead = xdoc.Elements("Type1").Elements("date").Where(a => a.Element("value").Value.Equals(dateTimePicker1.Value.ToString("yyyy-MM-dd"))).Elements("activity"); 
           
            if (xdocRead.Count() > 0)
            {
                activity1.Items.Clear();
                activity2.Items.Clear();
                activity3.Items.Clear();
                activity4.Items.Clear();
                activity5.Items.Clear();
                int count = 0;
				// if has value in name then get value and display in list box
				foreach (var n in xdocRead)
                {
                    foreach (var a in n.Elements("name"))
                    {
                        switch (count)
                        {
                            case 0:
                                activity1.Items.Add(a.Value);
                                break;
                            case 1:
                                activity2.Items.Add(a.Value);
                                break;
                            case 2:
                                activity3.Items.Add(a.Value);
                                break;
                            case 3:
                                activity4.Items.Add(a.Value);
                                break;
                            case 4:
                                activity5.Items.Add(a.Value);
                                break;
                            default:
                                break;
                        }
                    }
                    count++;

                   
                }
            }
            else
            {
				// if no value in name then clear list box and show the default activity as soccer
				activity1.Items.Clear();
                activity2.Items.Clear();
                activity3.Items.Clear();
                activity4.Items.Clear();
                activity5.Items.Clear();
                activity1.Items.Add("Soccer");
                activity2.Items.Add("Soccer");
                activity3.Items.Add("Soccer");
                activity4.Items.Add("Soccer");
                activity5.Items.Add("Soccer");
            }
        }


        private void addtoXML(int n, String b)
        {
			//load activities.xml
            XDocument xdoc = XDocument.Load("../../activities.xml");
			//read element activity
            var xdocRead = xdoc.Elements("Type1").Elements("date").Elements("activity");
            int count = 0;
			//add element into activity at selected session
            foreach (var x in xdocRead)
            {
                if (count == n)
                {
                    x.Add(new XElement("name", b));  
                }
                count++;
            }
			//save doc
            xdoc.Save("../../activities.xml");
           
        }
        private void addbutton_Click(object sender, EventArgs e)
        {
            

            String a = comboBox1.SelectedItem.ToString(); //Activity Session
            String b = textBox1.Text; //Activity Name
			//add acticity according to the session that has been selected
            switch (a){
                case "Activity1": {
                        addtoXML(0, b);
                        activity1.Items.Add(b);
                        break;
                    }
                case "Activity2": {
                        addtoXML(1, b);
                        activity2.Items.Add(b);
                        break;
                    }
                case "Activity3": {
                        addtoXML(2, b);
                        activity3.Items.Add(b);
                        break;
                    }
                case "Activity4":
                    {
                        addtoXML(3, b);
                        activity4.Items.Add(b);
                        break;
                    }
                case "Activity5":
                    {
                        addtoXML(4, b);
                        activity5.Items.Add(b);
                        break;
                    }
                default: {
                        break;
                    }
            }



        }

        private void del1_Click(object sender, EventArgs e)
        {
            Button del = (Button)sender;
            int tags = Convert.ToInt16(del.Tag) - 1;
            //MessageBox.Show(tags);
            ListBox[] listboxlist = { activity1, activity2, activity3, activity4, activity5 }; 
            XDocument xdoc = XDocument.Load("../../activities.xml");
            var xdocRead = xdoc.Elements("Type1").Elements("date").Elements("activity");
            int count = 0;
            foreach (var x in xdocRead)
            {
                if (count == tags)
                {
					//remove activity from xml
                    x.Elements("name").Where(a => a.Value == listboxlist[tags].Text).Single().Remove();
					//remove activity from list box
                    listboxlist[tags].Items.RemoveAt(listboxlist[tags].SelectedIndex);
                   
                }
                count++;
            }
			//save doc
            xdoc.Save("../../activities.xml");




        }
    }
}
