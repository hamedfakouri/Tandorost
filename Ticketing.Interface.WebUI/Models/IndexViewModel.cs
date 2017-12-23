using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ticketing.Interface.WebUI.Models
{
    public class IndexViewModel
    {
        public string ServiceHostUrl { get; set; }

        public IndexViewModel()
        {
            this.ServiceHostUrl = ConfigurationManager.AppSettings["ServiceHostUrl"];
        }
    }
}