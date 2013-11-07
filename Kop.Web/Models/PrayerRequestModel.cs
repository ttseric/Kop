using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kop.Core;

namespace Kop.Web.Models
{
    public class PrayerRequestModel
    {
        [DisplayName("發起人")]
        public string PrayBy { get; set; }


        public List<SelectListItem> CountryList { get; set; }

        [DisplayName("來自")]
        [Required(ErrorMessage = "請輸入閣下來自甚麼地方")]
        public string From { get; set; }

        [DisplayName("代禱內容")]
        [Required(ErrorMessage = "請輸入需要代禱的內容")]
        public string Detail { get; set; }
    }
}