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
using System.Windows.Forms;
using System.Xml.Linq;

namespace projectITE233
{
	public partial class SelectActivities : Form
	{
		public SelectActivities()
		{
			InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e) {
            XDocument xdoc = XDocument.Load("../../bunks.xml");
            var xdocRead = xdoc.Elements("Type1").Elements("bunk");
            foreach (var n in xdocRead) {
                bunkBox.Items.Add(n.Element("name").Value);
            }
            if (bunkBox.Items.Count > 0)
            {
                bunkBox.SelectedIndex = 0;
            }

            XDocument xdoc2 = XDocument.Load("../../camper.xml");
            var xdocRead2 = xdoc2.Elements("Type1").Elements("item");
            foreach (var n in xdocRead2)
            {
                nameBox.Items.Add(n.Element("name").Value);
            }
        }

     
    }
}

