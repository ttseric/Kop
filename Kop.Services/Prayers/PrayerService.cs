using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using Kop.Core;
using Kop.Core.Data;

namespace Kop.Services.Prayers
{
    public class PrayerService : IPrayerService
    {
        private readonly IRepository<Prayer> _prayerRepository;
        private readonly IRepository<User> _userRepository;

        public PrayerService(IRepository<Prayer> prayerRepository, IRepository<User> userRepository)
        {
            _prayerRepository = prayerRepository;
            _userRepository = userRepository;
        }

        public void InsertPrayer(Prayer prayer)
        {
            _prayerRepository.Insert(prayer);
        }

        public void UpdatePrayer(Prayer prayer)
        {
            _prayerRepository.Update(prayer);
        }

        public IList<Prayer> GetPrayers()
        {
            return _prayerRepository.Table.Include("RequestBy").Include("PrayerAnswer").ToList();
        }

        public void SupportPrayer(int prayerId, int userId)
        {
            var prayer = _prayerRepository.GetById(prayerId);

            prayer.Support += 1;

            if (userId != 0 && AnyUserPrayer(prayerId, userId) == false)
            {
                var supportUser = _userRepository.GetById(userId);
                prayer.AddSupportBy(supportUser);
            }

            _prayerRepository.Update(prayer);
        }

        private bool AnyUserPrayer(int prayerId, int userId)
        {
            return
                _prayerRepository.Table.Any(
                    x => x.SupportByUsers.Any(
                        y => y.Prayer.PrayerId == prayerId && y.User.UserId == userId));
        }

        public Prayer GetPrayer(int prayerId)
        {
            return _prayerRepository.Table.Include("RequestBy").Include("PrayerAnswer").First(x => x.PrayerId == prayerId);
        }


        public void PraiseGod(int prayerId)
        {
            var prayer = GetPrayer(prayerId);

            prayer.PrayerAnswer.PraiseGodCount += 1;

            _prayerRepository.Update(prayer);
        }
    }
}
