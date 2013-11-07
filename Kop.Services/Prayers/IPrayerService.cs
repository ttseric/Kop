using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;
using Kop.Core.Data;

namespace Kop.Services.Prayers
{
    public interface IPrayerService
    {
        void InsertPrayer(Prayer prayer);
        void UpdatePrayer(Prayer prayer);
        IList<Prayer> GetPrayers();
        void SupportPrayer(int prayerId, int userId);
        Prayer GetPrayer(int prayerId);
        void PraiseGod(int prayerId);
    }
}
