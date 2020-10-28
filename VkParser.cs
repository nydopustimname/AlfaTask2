﻿using AngleSharp.Html.Dom;
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
            Stream stream = client.OpenRead(url);
            if (stream == null)
                return "Invalid link";
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
            else return "Page is available only to authorized users(";
        }

       

    }
}
