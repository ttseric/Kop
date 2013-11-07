using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Services.Countries
{
    public interface ICountryService
    {
        List<Country> GetCountries();

        Country GetCountry(int p);
    }
}
