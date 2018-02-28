using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public string Index()
        {
            return "This is my <b>default<b> action..";
        }
        public string Welcome(string name,int numTimes=1)
        {
            return HttpUtility.HtmlAttributeEncode("Hello" + name + ",NumTimes is:" + numTimes);
        }
    }
}