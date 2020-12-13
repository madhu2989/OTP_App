using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace WebApplication3
{
    public partial class wewbform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }



        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Random rndm = new Random();
                int value = rndm.Next(11111, 99999);
                string dstnaddrs = "91" + TextBox1.Text;
                string msg = " Your OTP is : " + value +
                    "- Naan kalsiddu kanro #E Sala Cup Namde,(sent by MADDY Application)";
                string msg1 = HttpUtility.UrlEncode(msg);

                using (var wc = new WebClient())
                {
                    byte[] response = wc.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                        //2bgAg5Ag9HY-83XFdBqAz09X9i3rOUryA12Vo2eIEl
                    {"apikey" , "g1nql5klz8k-lSYnGp0Kr5b4QS9XDdmYvWPyXHROZ4	" },
                    {"numbers" , dstnaddrs },
                    {"message" , msg1 },
                    {"Sender" , "MADHUSUDHAN" }
                });

                    string res = System.Text.Encoding.UTF8.GetString(response);
                    Session["OTP"] = value;
                }






            }
            catch (Exception)
            {
                
                throw;
                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox2.Text == Session["OTP"].ToString())
                {
                    Label3.Visible = false;
                    Panel2.Visible = false;
                    Label2.Text = "Your mobile number has been verified successfully";

                    string dstnaddrs = "91" + TextBox1.Text;
                    string msg = "Your mobile number has been verified successfully.";
                    string msg1 = HttpUtility.UrlEncode(msg);

                    using (var wc = new WebClient())
                    {
                        byte[] response = wc.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                    {"apikey" , "g1nql5klz8k-lSYnGp0Kr5b4QS9XDdmYvWPyXHROZ4	" },
                    {"numbers" , dstnaddrs },
                    {"message" , msg1 },
                    {"Sender" , "MADHUSUDHAN" }
                });
                    }
                }
                else
                {
                    Panel2.Visible = true;
                    Label3.Text = "OTP is incorrect";
                }
            }


            catch (Exception)
            {

                throw;
            }
        }
    }
}
