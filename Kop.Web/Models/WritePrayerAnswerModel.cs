using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kop.Core;

namespace Kop.Web.Models
{
    public class WritePrayerAnswerModel
    {
        public WritePrayerAnswerModel()
        {  
        }

        public WritePrayerAnswerModel(Prayer prayer)
        {
            From = prayer.From;
            Detail = prayer.Detail;
            RequestBy = prayer.RequestBy.Name;
            Support = prayer.Support;
            Id = prayer.PrayerId;
            SubmitDate = prayer.SubmitDate;

            if (prayer.PrayerAnswer != null)
            {
                PrayerAnswer = prayer.PrayerAnswer.Detail;
            }
        }

        public string PrayerAnswer { get; set; }

        public string From { get; set; }

        public string Detail { get; set; }

        public string RequestBy { get; set; }

        public int Support { get; set; }

        public int Id { get; set; }

        public DateTime SubmitDate { get; set; }

        public string SharedTime
        {
            get
            {
                var different = DateTime.Now.Subtract(SubmitDate);

                if (different.TotalSeconds <= 59)
                    return string.Format("{0} 秒鐘前發佈", (int)different.TotalSeconds);

                if (different.TotalMinutes <= 59)
                    return string.Format("{0} 分鐘前發佈", (int)different.TotalMinutes);

                if (different.TotalHours <= 23)
                    return string.Format("{0} 小時前發佈", (int)different.TotalHours);

                return string.Format("{0} 日前發佈", (int)different.TotalDays);
            }
        }
    }
}