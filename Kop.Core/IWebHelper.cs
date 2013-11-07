using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kop.Core
{
    public interface IWebHelper
    {
        bool RequestIsAuthenticated { get; }
        string UserIdentityName { get; }
        void SignIn(string name);
        void SignOut();
    }
}
