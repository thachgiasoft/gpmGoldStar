﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang
{
    /// <summary>
    /// Summary description for KeepAlive
    /// </summary>
    public class KeepAlive : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}