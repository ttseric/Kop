using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;
using Kop.Core.Data;

namespace Kop.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void InsertUser(User user)
        {
            if (AnyName(user.LoginName))
                throw new Exception("Duplicated user name.");

            _userRepository.Insert(user);
        }

        public bool AnyName(string loginName)
        {
            return _userRepository.Table.Any(x => x.LoginName == loginName);
        }

        public User Login(string loginName, string password)
        {
            return _userRepository.Table.FirstOrDefault(x => x.LoginName == loginName && x.Password == password);
        }

        public User GetByIdIncludeAll(int id)
        {
            return _userRepository.Table.Include("RequestPrayers")
                .Include("SupportingPrayers")
                .Include("SupportingPrayers.Prayer")
                .Include("SupportingPrayers.Prayer.RequestBy")
                .Include("SupportingPrayers.Prayer.PrayerAnswer")
                .Include("Country")
                .First(x => x.UserId == id);
        }

        public User GetByName(string loginName)
        {
            return _userRepository.Table.First(x => x.LoginName == loginName);
        }

        public User GetAnonymousUser()
        {
            return GetByIdIncludeAll(1);
        }
    }
}
