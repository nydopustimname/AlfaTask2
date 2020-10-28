using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using AngleSharp.Html.Parser;
using System.Threading;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace AlfaTask2
{
   public class VkParser
    {
       
        private readonly ulong AppId = 7642894;
        private readonly VkApi Vkapi;
        ApiAuthParams ApiParams;

        public event OnCompleted OnCompleted;
        public event NewMessage NewMessage;

        public VkParser()
        {
            Vkapi = new VkApi();
            ApiParams = new ApiAuthParams();
        }

        UserModel user;
        protected UserModel userModel
        {
            get => user;
            set
            {
                user = value;
            }
        }

        public bool VkAuth(string login, string password)
        {
            ApiParams.ApplicationId = AppId;
            ApiParams.Login = login;
            ApiParams.Password = password;
            ApiParams.Settings = Settings.All;

             Vkapi.AuthorizeAsync(ApiParams);

            if (Vkapi.IsAuthorized) NewMessage?.Invoke("Вы авторизировались");
            return Vkapi.IsAuthorized;
        }
        
       
        public string ParseAsync(string url)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            Stream stream;
            try
            {
             stream = client.OpenRead(url);
            }
            catch(Exception e)
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
            else return "Page is available only to authorized users(";
        }

       

    }
}
