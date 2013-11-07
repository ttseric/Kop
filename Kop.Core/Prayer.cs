using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class Prayer
    {
        public int PrayerId { get; set; }
        public string Detail { get; set; }
        public DateTime SubmitDate { get; set; }
        public string From { get; set; }
        public int Support { get; set; }
        public User RequestBy { get; set; }        
        public PrayerAnswer PrayerAnswer { get; set; }

        List<UserPrayer> _supportByUsers = new List<UserPrayer>();
        public List<UserPrayer> SupportByUsers
        {
            get { return _supportByUsers; }
            set { _supportByUsers = value; }
        }

        public void AddSupportBy(User user)
        {
            _supportByUsers.Add(new UserPrayer()
                {
                    Prayer = this,
                    User = user
                });
        }
    }
}
