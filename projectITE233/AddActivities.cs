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
			var xdocRead = xdoc.Elements("Type1").Elements("date").Elements("activity"); //";//.Where(a => a.Element("value").Equals() );
																   //clear listbox
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
						}
						
						
					}
					count++;

					//count++;
				}
			}
			
		}
	}
}
