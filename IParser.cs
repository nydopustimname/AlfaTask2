using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlfaTask2
{

    public delegate void NewMessage(string message);
    public delegate void OnCompleted();

    public interface IParser
    {
        
        event OnCompleted OnCompleted;
        Task<bool> VkAuth(string login, string password, string captcha = null, long? sid = null);
        void ParseAsync(string usrId);


    }
}
