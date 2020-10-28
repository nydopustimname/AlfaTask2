using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace AlfaTask2
{
    public class VkParser
    {
       
        public string ParseAsync(string url)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            Stream stream;
            try
            {
                stream = client.OpenRead(url);
            }
            catch (Exception e)
            {
                return "Invalid link";
            }
            StreamReader sr = new StreamReader(stream);
            string newLine;

            string ss = "";
            while ((newLine = sr.ReadLine()) != null)
            {
                ss += newLine;
            }

            String st = Regex.Match(ss, ("<div class=\"pp_status\">(.*?)</div>")).Value;
            
            string pattern= @"(<div class=\""pp_status\"">|</div>)";
            string status = Regex.Replace(st, pattern, String.Empty);
            if (st != ""&& status!="")
                return status;
            else return "User has no status or page is available only to authorized users";
        }

       

    }
}
