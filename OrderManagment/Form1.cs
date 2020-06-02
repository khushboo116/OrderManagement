using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OrderManagment
{
    public partial class Form1 : Form
    {
        private frmAdmin Admin;
        private frmUser User;
        public Form1()
        {
            InitializeComponent(); 
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (User == null)
            {
                User = new frmUser();
            }
            else
            {
                User.Dispose();
                User = new frmUser();
            }
            User.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (Admin == null)
            {
                Admin = new frmAdmin();
            }
            else
            {
                Admin.Dispose();
                Admin = new frmAdmin();
            }
            Admin.Show();

        }
    }
}
