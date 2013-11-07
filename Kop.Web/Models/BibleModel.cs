using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kop.Web.Models
{
    public class BibleModel
    {
        public string BibleBookNameChiAbbr { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }
        public int BibleId { get; set; }

    }
}