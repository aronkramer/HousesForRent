using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HousesForRent.Models
{
    [Authorize]
    public class PaymentController : Controller
    {
        public void Index(string cc, string exp, string cvv)
        {
            // Request
            var MyPost = new NameValueCollection();
            MyPost.Add("xKey", "frumrentaldevcfca8ef0f65b4649ba1d8025a0923031");
            MyPost.Add("xVersion", "4.5.8");
            MyPost.Add("xSoftwareName", "FrumRentals"); 
            MyPost.Add("xSoftwareVersion", "1.0"); 
            MyPost.Add("xCommand", "cc:sale");
            MyPost.Add("xCardNum", cc);
            MyPost.Add("xExp", exp);
            MyPost.Add("xCVV", cvv);
            MyPost.Add("xAmount", "9.99");

            var MyClient = new System.Net.WebClient();
            string MyResponse = Encoding.ASCII.GetString(MyClient.UploadValues("https://x1.cardknox.com/gateway", MyPost));
            // Response
            NameValueCollection MyResponseData = HttpUtility.ParseQueryString(MyResponse);
            string MyResult = "";
            if (MyResponseData.AllKeys.Contains("xResult"))
                MyResult = MyResponseData["xResult"];
            string MyStatus = "";
            if (MyResponseData.AllKeys.Contains("xStatus"))
                MyStatus = MyResponseData["xStatus"];
            string MyError = "";
            if (MyResponseData.AllKeys.Contains("xError"))
                MyError = MyResponseData["xError"];
            string MyRefNum = "";
            if (MyResponseData.AllKeys.Contains("xRefNum"))
                MyRefNum = MyResponseData["xRefNum"];
            if(MyStatus == "Approved")
            {
                Session["paymentResult"] = "Payment Approved";
            }
            else
            {
                Session["paymentResult"] = $"Payment NOT Approved: {MyError}";
            }
        }
    }
}