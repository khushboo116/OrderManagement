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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
            lblWelcome.Font = new Font("Arial", 20);
            cmbOrderType.DataSource = Utility.GetOrderType();
        }
         
        private void actionPerform(string orderType)
        { 
            var json = File.ReadAllText("../../Order.json");
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray ordersArrary = (JArray)jObject["orders"];
                    if (ordersArrary != null)
                    { 
                        foreach (var item in ordersArrary)
                        { 
                            if(item["orderId"].ToString()== orderType)
                            {
                                string[] actionDetails = item["action"].ToString().Split('#');
                                foreach (var val in actionDetails)
                                {
                                    MessageBox.Show(val.ToString());
                                }
                            }
                            
                        }
                    }
                }
            }
            catch (Exception)
            {

            } 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string orderType = cmbOrderType.SelectedValue.ToString();
            actionPerform(orderType);

        }
    }
     class OrderDetails
    {
        public string orderid { get; set; }
        public string orderAction { get; set; }
    }
}
