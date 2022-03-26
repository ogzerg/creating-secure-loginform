using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace gitHub
{
    internal class checkClass
    {
        string url = "http://127.0.0.1/loginrequest.php";
        public int checkUser(string user, string pass)
        {
            try
            {
                var wb = new WebClient();
                var data = new NameValueCollection();
                data["user"] = user;
                data["pass"] = pass;
                data["loginCheck"] = "1";//Anything can be written. It's okay.
                var response = wb.UploadValues(url, "POST", data);
                string result = Encoding.UTF8.GetString(response);
                JObject jsResult = JObject.Parse(result);
                if (jsResult["result"].ToString().Equals("1"))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
