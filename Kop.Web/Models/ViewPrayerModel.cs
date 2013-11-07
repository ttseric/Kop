using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kop.Core;

namespace Kop.Web.Models
{
    public class ViewPrayerModel
    {
        private readonly Prayer _prayer;

        public ViewPrayerModel(Prayer prayer)
        {
            _prayer = prayer;
        }

        public string From
        {
            get { return _prayer.From; }
        }

        public string Detail
        {
            get { return _prayer.Detail; }
        }

        public string RequestBy
        {
            get { return _prayer.RequestBy.Name; }
        }

        public int Support
        {
            get { return _prayer.Support; }
        }
        
        public int Id
        {
            get { return _prayer.PrayerId; }
        }

        public string SharedTime
        {
            get
            {
                var different = DateTime.Now.Subtract(_prayer.SubmitDate);

                if (different.TotalSeconds <= 60)
                    return string.Format("{0} 秒鐘前發佈", (int)different.TotalSeconds);

                if (different.TotalMinutes <= 60)
                    return string.Format("{0} 分鐘前發佈", (int)different.TotalMinutes);

                if (different.TotalHours <= 24)
                    return string.Format("{0} 小時前發佈", (int)different.TotalHours);

                return string.Format("{0} 日前發佈", (int)different.TotalDays);
            }
        }

        public PrayerAnswer PrayerAnswer
        {
            get { return _prayer.PrayerAnswer; }
        }

    }
}