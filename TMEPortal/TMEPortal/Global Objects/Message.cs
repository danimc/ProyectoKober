using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMEPortal.Global_Objects
{


    public class Message
    {
        public string Error(string Mensaje)
        {
            return "'Oops...','"+ Mensaje + "',  'error'";
        }
    }
}