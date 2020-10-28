using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AlfaTask2
{
   public class UserModel
    {
        public static string Id { get; set; }
        public string Name { get; set; }
        public string SName { get; set; }
        public string Status { get; set; }

        public UserModel(string id)
        {
            Id = id;
        }

    }
}
