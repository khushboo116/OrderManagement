using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment
{
    public static class Utility
    {
        // Add method in utitlity class 
        public static List<string> GetOrderType()
        {
            List<string> orderType = new List<string>();
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
                            orderType.Add(item["orderId"].ToString());
                        }

                    }
                }
            }
            catch (Exception)
            {

            }
            return orderType;
        }
    }
}
