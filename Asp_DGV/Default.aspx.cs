using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp_DGV
{
    public partial class _Default : Page
    {
        ArrayList datestamps;
        protected void Page_Load(object sender, EventArgs e)
        {
       
            if (Cache["datestamps"] == null)
            {
                datestamps = new ArrayList();
                datestamps.Add(DateTime.Now);
                datestamps.Add(DateTime.Now);
                datestamps.Add(DateTime.Now);

                Cache.Add("datestamps", datestamps, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 60), System.Web.Caching.CacheItemPriority.Default, null);
            }
            else
                datestamps = (ArrayList)Cache["datestamps"];

            foreach (DateTime dt in datestamps)
                Response.Write(dt.ToString() + "<br />");

        }
        protected static string GetFreshDateTime(HttpContext context)
        {
            return DateTime.Now.ToString();
        }
    }
}