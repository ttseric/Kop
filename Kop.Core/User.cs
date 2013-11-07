using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public Country Country { get; set; }
        private List<Prayer> _requestPrayers = new List<Prayer>();
        private List<UserPrayer> _supportingPrayers = new List<UserPrayer>();

        public List<UserPrayer> SupportingPrayers
        {
            get { return _supportingPrayers; }
            set { _supportingPrayers = value; }
        }

        public List<Prayer> RequestPrayers
        {
            get { return _requestPrayers; }
            set { _requestPrayers = value; }
        }

        public void Support(Prayer prayer)
        {
            SupportingPrayers.Add(new UserPrayer()
                {
                    Prayer = prayer,
                    User = this
                });
        }
    }
}
