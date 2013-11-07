using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kop.Core;

namespace Kop.Web.Models
{
    public class ViewPrayersModel
    {
        public ViewPrayersModel(IEnumerable<Prayer> prayers)
        {
            Prayers = new List<ViewPrayerModel>();

            foreach (var prayer in prayers)
            {
                Prayers.Add(new ViewPrayerModel(prayer));
            }
        }
        public IList<ViewPrayerModel> Prayers { get; set; }
    }
}