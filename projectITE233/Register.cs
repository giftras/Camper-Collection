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
			NewCamper session = new NewCamper();
			session.ShowDialog();
		}
	}
}
