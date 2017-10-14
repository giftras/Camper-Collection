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
//using System.Windows.Forms;
using System.Xml.Linq;

namespace projectITE233
{
	public partial class SelectActivities : Form
	{
		public SelectActivities()
		{
			InitializeComponent();
        }

		private void Form_Load(object sender, EventArgs e)
		{
			//Load document
			XDocument xdoc = XDocument.Load("../../bunks.xml");
			//read bunk
			var xdocRead = xdoc.Elements("Type1").Elements("bunk");
			foreach (var n in xdocRead)
			{
				bunkBox.Items.Add(n.Value);
			}
			if (bunkBox.Items.Count > 0)
			{
				bunkBox.SelectedIndex = 0;
			}

			//load camper
			XDocument xdoc2 = XDocument.Load("../../camper.xml");
			//read item where the bunk value and get name at that value
			var xdocRead2 = xdoc2.Elements("Type1").Elements("item").Where(a => a.Element("bunk").Value == bunkBox.Text);
			foreach (var n in xdocRead2)
			{
				nameBox.Items.Add(n.Element("name").Value);
			}

			XDocument xdoc3 = XDocument.Load("../../activities.xml");
			// read activity in that day
			var xdocRead3 = xdoc3.Elements("Type1").Elements("date").Where(a => a.Element("value").Value.Equals(dateTimePicker1.Value.ToString("yyyy-MM-dd"))).Elements("activity");
            if (xdocRead3.Count() > 0)
			{
				//clear list box
				sub1.Items.Clear();
				sub2.Items.Clear();
				sub3.Items.Clear();
				sub4.Items.Clear();
				sub5.Items.Clear();
				int count = 0;
				foreach (var n in xdocRead3)
				{
					// if has value in name then get value and display in list box
					foreach (var a in n.Elements("name"))
					{
						switch (count)
						{
							case 0:
								sub1.Items.Add(a.Value);
								break;
							case 1:
								sub2.Items.Add(a.Value);
								break;
							case 2:
								sub3.Items.Add(a.Value);
								break;
							case 3:
								sub4.Items.Add(a.Value);
								break;
							case 4:
								sub5.Items.Add(a.Value);
								break;
						}


					}
					count++;

					
				}

			}
            else
            {
				// if no value in name then clear list box and show the default activity as soccer
                sub1.Items.Clear();
                sub2.Items.Clear();
                sub3.Items.Clear();
                sub4.Items.Clear();
                sub5.Items.Clear();
                sub1.Items.Add("Soccer");
                sub2.Items.Add("Soccer");
                sub3.Items.Add("Soccer");
                sub4.Items.Add("Soccer");
                sub5.Items.Add("Soccer");
            }
        }

       


        private void Save_Click(object sender, EventArgs e)
        {
			//load selectedActivities.xml
			XDocument xdoc = XDocument.Load("../../selectedActivities.xml");
            XElement root = xdoc.Root;
			//add element to selectedActivities.xml 
			//if added the same value, it will add data twice
			root.Add(
                new XElement("Bunk", bunkBox.SelectedItem.ToString()),
                new XElement("Name", nameBox.SelectedItem.ToString()),
                new XElement("Date", dateTimePicker1.Value.ToString("yyyy-MM-dd")),
                new XElement("Activity1", sub1.SelectedItem.ToString()),
                new XElement("Activity2", sub2.SelectedItem.ToString()),
                new XElement("Activity3", sub3.SelectedItem.ToString()),
                new XElement("Activity4", sub4.SelectedItem.ToString()),
                new XElement("Activity5", sub5.SelectedItem.ToString())
                );

            xdoc.Save("../../selectedActivities.xml");
			//close the window when click save
            this.Close();
        }


		private void bunkBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if bunk changed the name in dropdown menu will change too
			XDocument xdoc2 = XDocument.Load("../../camper.xml");
			var xdocRead2 = xdoc2.Elements("Type1").Elements("item").Where(a => a.Element("bunk").Value == bunkBox.Text);
			nameBox.Items.Clear();
			foreach (var n in xdocRead2)
			{
				nameBox.Items.Add(n.Element("name").Value);
			}
			// clear name box if change to another index
			if(nameBox.Items.Count > 0)
			{
				nameBox.SelectedIndex = 0;
			}
			else
			{
				nameBox.Text = "";
			}
		}
	}
}

