using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Services.Users
{
    public interface IUserService
    {
        void InsertUser(User user);        
        bool AnyName(string loginName);
        User Login(string loginName, string password);
        User GetByName(string loginName);
        User GetByIdIncludeAll(int id);
        User GetAnonymousUser();
    }
}
