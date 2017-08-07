using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BanHang.Data
{
    public class StaticContext
    {
        public static string ConnectionString = WebConfigurationManager.ConnectionStrings["BanHangConnectionString"].ConnectionString;
       
    }
}