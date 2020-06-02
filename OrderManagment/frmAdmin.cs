using Newtonsoft.Json;
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

namespace OrderManagment
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            lblWelcome.Font = new Font("Arial", 20);
            cmbOrderType.DataSource = Utility.GetOrderType();
        }

       


        private void actionAdd(string orderType, string orderDetail)
        {
            string json = File.ReadAllText("../../Order.json");
            string message = string.Empty;
            try
            {
                var jObject = JObject.Parse(json);
                JArray orderData = (JArray)jObject["orders"];
                foreach (var order in orderData.Where(obj => obj["orderId"].Value<string>() == orderType))
                {
                    order["action"] = order["action"] + "#" + orderDetail;
                    message = order["action"].ToString().Replace("#", ",");
                }
                jObject["orders"] = orderData;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("../../Order.json", output);
                MessageBox.Show("Updated Actions are : -" + message);
                tbAction.Text = "";

            }
            catch (Exception ex)
            {

                Console.WriteLine("Update Error : " + ex.Message.ToString());
            }
        }


        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (tbAction.Text == "")
            {
                MessageBox.Show("Please add action");
            }
            else
            {
                tbAction.Text.Replace("#", " ");
                actionAdd(cmbOrderType.SelectedValue.ToString(), tbAction.Text);
            }

        }
    }
}
