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

		private void button6_Click(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			campSession session = new campSession();
			session.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Register session = new Register();
			session.ShowDialog();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			SelectActivities session = new SelectActivities();
			session.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			AddActivities session = new AddActivities();
			session.ShowDialog();
		}
	}
}
