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
			XDocument xdoc = XDocument.Load("../../bunks.xml");
			var xdocRead = xdoc.Elements("Type1").Elements("bunk");
			foreach (var n in xdocRead)
			{
				bunkBox.Items.Add(n.Value);
			}
			if (bunkBox.Items.Count > 0)
			{
				bunkBox.SelectedIndex = 0;
			}

			XDocument xdoc2 = XDocument.Load("../../camper.xml");
			var xdocRead2 = xdoc2.Elements("Type1").Elements("item").Where(a => a.Element("bunk").Value == bunkBox.Text);
			foreach (var n in xdocRead2)
			{
				nameBox.Items.Add(n.Element("name").Value);
			}

			XDocument xdoc3 = XDocument.Load("../../activities.xml");
			// read items
			var xdocRead3 = xdoc3.Elements("Type1").Elements("date").Elements("activity");
			if (xdocRead3.Count() > 0)
			{
				sub1.Items.Clear();
				sub2.Items.Clear();
				sub3.Items.Clear();
				sub4.Items.Clear();
				sub5.Items.Clear();
				int count = 0;
				foreach (var n in xdocRead3)
				{
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

					//count++;
				}

				//            XDocument xdocA = XDocument.Load("../../activities.xml");
				//            var xdocReadA = xdocA.Elements("Type1").Elements("item").Elements("subject").Elements("activities");
				//          foreach (var n in xdocReadA)
				//            {
				//                sub1.Items.Add(n.Element("activityname").Value);
				//            }

			}
		}


        private void Save_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load("../../selectedActivities.xml");
            XElement root = xdoc.Root;
            root.Add(
                new XElement("Bunk", bunkBox.SelectedItem.ToString()),
                new XElement("Name", nameBox.SelectedItem.ToString()),
                new XElement("Date",dateTimePicker1.ToString()),
                new XElement("Activity1", sub1.SelectedItem.ToString()),
                new XElement("Activity2", sub2.SelectedItem.ToString()),
                new XElement("Activity3", sub3.SelectedItem.ToString()),
                new XElement("Activity4", sub4.SelectedItem.ToString()),
                new XElement("Activity5", sub5.SelectedItem.ToString())
                );

            xdoc.Save("../../selectedActivities.xml");

            this.Close();
        }


		private void bunkBox_SelectedIndexChanged(object sender, EventArgs e)
		{
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

