using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kop.Core;

namespace Kop.Web.Models
{
    public class CreatePrayerTemplateModel
    {
        public List<SelectListItem> PrayerTemplateCategories { get; set; }
        public int SelectedCategory { get; set; }        
        public string Name { get; set; }
        public List<SelectListItem> BibleBooks { get; set; }
        public string Introduction { get; set; }
        public string Detail { get; set; }
        public string SelectedBible { get; set; } 
    }
}