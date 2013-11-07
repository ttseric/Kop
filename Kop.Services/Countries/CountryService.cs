using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;
using Kop.Core.Data;

namespace Kop.Services.Countries
{
    public class CountryService:ICountryService
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public List<Country> GetCountries()
        {
            return _countryRepository.Table.ToList();
        }


        public Country GetCountry(int countryId)
        {
            return _countryRepository.GetById(countryId);
        }
    }
}
