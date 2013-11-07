using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public class UserPrayer
    {
        public int UserPrayerId { get; set; }
        public User User { get; set; }
        public Prayer Prayer { get; set; }
    }
}
