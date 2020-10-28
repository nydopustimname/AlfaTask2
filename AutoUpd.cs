using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AutoItX3Lib;

namespace AlfaTask2
{
   public class AutoUpd
    {
        public void Upd()
        {
           
                AutoItX3 autoIt = new AutoItX3();
               // autoIt.MouseMove(350, 400, 10);
                autoIt.MouseClick("LEFT", 350, 400, 1, 10);
               // Thread.Sleep(4600);

        }
       

    }
}
