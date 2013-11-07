using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kop.Core;
using System.Web.WebPages.Html;

namespace Kop.Web.Models
{
    public class SearchBibleModel
    {
        public List<Bible> DisplayBibles { get; set; }        
        public List<BibleBook> BibleBooks { get; set; }
        public List<int> Chatpers { get; set; }

    }
}