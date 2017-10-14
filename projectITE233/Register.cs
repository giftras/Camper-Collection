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
	public partial class Register : Form
	{
		public Register()
		{
			InitializeComponent();
		}

		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			XDocument xdoc = XDocument.Load("../../camper.xml");
			//create new element
			XElement newTag = new XElement("item",
				new XElement("name", name.Text),
				new XElement("nickname", nickname.Text),
				new XElement("bunk", comboBox2.Text),
				new XElement("age", age.Text),
				new XElement("nationality", nationality.Text), 
				new XElement("restriction", restriction.Text),
				new XElement("medications", medication.Text),
				new XElement("transportation", transpotation.Text),
				new XElement("startdate", StartDate.Value.ToString("yyyy-MM-dd")),
				new XElement("enddate", EndDate.Value.ToString("yyyy-MM-dd")),
				new XElement("nameParent1", nameparent1.Text),
				new XElement("phoneParent1", phoneparent1.Text),
				new XElement("emailParent1", emailparent1.Text),
				new XElement("nameParent2", nameparent2.Text),
				new XElement("phoneParent2", phoneparent2.Text),
				new XElement("emailParent2", emailparent2.Text)
				);
			//add element to the document under type one element
				xdoc.Element("Type1").Add(newTag);
			//save doc
			xdoc.Save("../../camper.xml");
			//reload the form
			Register_Load(sender, e);
		}

		private void Register_Load(object sender, EventArgs e)
		{
			//Load document
			XDocument xdoc = XDocument.Load("../../camper.xml");
			// read items
			var xdocRead = xdoc.Elements("Type1").Elements("item");
			//clear textbox
			comboBox1.Items.Clear();
			//load to combobox for all element name
			foreach (var n in xdocRead)
			{
				comboBox1.Items.Add(n.Element("name").Value.ToString());
			}
			//for bunk selection
			XDocument xdoc2 = XDocument.Load("../../bunks.xml");
			var xdocRead2 = xdoc2.Elements("Type1").Elements("bunk");
			foreach (var n in xdocRead2)
			{
				comboBox2.Items.Add(n.Value);
			}
			if (comboBox2.Items.Count > 0)
			{
				comboBox2.SelectedIndex = 0;
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			XDocument xdoc = XDocument.Load("../../camper.xml");
			var xdocRead = xdoc.Elements("Type1").Elements("item");
			//read for item where element name is same with comboBox
			var item = xdocRead.Where(a => a.Element("name").Value == comboBox1.Text).Single();
			//get camper info
			name.Text = item.Element("name").Value;
			nickname.Text = item.Element("nickname").Value;
			comboBox2.Text = item.Element("bunk").Value;
			age.Text = item.Element("age").Value;
			nationality.Text = item.Element("nationality").Value;
			restriction.Text = item.Element("restriction").Value;
			medication.Text = item.Element("medications").Value;
			transpotation.Text = item.Element("transportation").Value;
			StartDate.Text =item.Element("startdate").Value;
			EndDate.Text = item.Element("enddate").Value;
			nameparent1.Text = item.Element("nameParent1").Value;
			phoneparent1.Text = item.Element("phoneParent1").Value;
			emailparent1.Text = item.Element("emailParent1").Value;
			nameparent2.Text = item.Element("nameParent2").Value;
			phoneparent2.Text = item.Element("phoneParent2").Value;
			emailparent2.Text = item.Element("emailParent2").Value;
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			XDocument xdoc = XDocument.Load("../../camper.xml");
			var xdocRead = xdoc.Elements("Type1").Elements("item");
			//delete the element where name is same with comboBox
			xdocRead.Where(a => a.Element("name").Value == comboBox1.Text).Single().Remove();
			//save doc
			xdoc.Save("../../camper.xml");
			//reload form
			Register_Load(sender, e);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			XDocument xdoc = XDocument.Load("../../camper.xml");
			var xdocRead = xdoc.Elements("Type1").Elements("item");
			var item = xdocRead.Where(a => a.Element("name").Value == comboBox1.Text).Single();
			// change camper info
			//item.Element("name").Value = name.Text; // cannot edit name
			item.Element("nickname").Value = nickname.Text;
			item.Element("bunk").Value = comboBox2.Text;
			item.Element("age").Value = age.Text;
			item.Element("nationality").Value = nationality.Text;
			item.Element("restriction").Value = restriction.Text;
			item.Element("medications").Value = medication.Text;
			item.Element("transportation").Value = transpotation.Text;
			item.Element("startdate").Value = StartDate.Value.ToString("yyyy-MM-dd");
			item.Element("enddate").Value = EndDate.Value.ToString("yyyy-MM-dd");
			item.Element("nameParent1").Value = nameparent1.Text;
			item.Element("phoneParent1").Value = phoneparent1.Text;
			item.Element("emailParent1").Value = emailparent1.Text;
			item.Element("nameParent2").Value = nameparent2.Text;
			item.Element("phoneParent2").Value = phoneparent2.Text;
			item.Element("emailParent2").Value = emailparent2.Text;
			//save doc that was changed
			xdoc.Save("../../camper.xml");
		}
	}
}
