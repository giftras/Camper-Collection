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
			//Load document
			XDocument xdoc = XDocument.Load("../../activities.xml");
			// read items
			var xdocRead = xdoc.Elements("Type1").Elements("date").Elements("activity"); ///.Where(a => a.Element("value").Equals() );
            //var xdocRead = xdoc.Elements("Type1").Elements("date").Where(a => a.Element("value").Value == ???).Elements("activity");
            //MessageBox.Show(xdoc.Elements("Type1").Elements("date").ElementAt(0).ToString());
            if (xdocRead.Count() > 0)
			{
				activity1.Items.Clear();
				activity2.Items.Clear();
				activity3.Items.Clear();
				activity4.Items.Clear();
				activity5.Items.Clear();
				int count = 0;
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

					//count++;
				}
			}
			
		}

        private void addtoXML(int n, String b)
        {
            XDocument xdoc = XDocument.Load("../../activities.xml");
            //XElement root = xdoc.Root;
            var xdocRead = xdoc.Elements("Type1").Elements("date").Elements("activity");
            int count = 0;
            foreach (var x in xdocRead)
            {
                if (count == n)
                {
                    x.Add(new XElement("name", b));  
                }
                count++;
            }
            xdoc.Save("../../activities.xml");
        }
        private void addbutton_Click(object sender, EventArgs e)
        {
            

            String a = comboBox1.SelectedItem.ToString(); //Activity Session
            String b = textBox1.Text; //Activity Name

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
                  //  MessageBox.Show(x.Elements("name")ToString());
                    x.Elements("name").Where(a => a.Value == listboxlist[tags].Text).Single().Remove();
                    listboxlist[tags].Items.RemoveAt(listboxlist[tags].SelectedIndex);
                    //x.Elements("Type1").Elements("date").Where(a => a.Element("name").Value == comboBox1.Text).Single().Remove();
                }
                count++;
            }
            xdoc.Save("../../activities.xml");




        }
    }
}
