using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectITE233
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//open register page into the new window
			Register session = new Register();
			session.ShowDialog();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			//open select activity page into the new window
			SelectActivities session = new SelectActivities();
			session.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//open add activity page into the new window
			AddActivities session = new AddActivities();
			session.ShowDialog();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
