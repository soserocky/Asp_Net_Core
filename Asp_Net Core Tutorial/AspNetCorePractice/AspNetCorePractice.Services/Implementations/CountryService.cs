using AspNetCorePractice.Data.DBContext;
using AspNetCorePractice.Models.DTOs;
using AspNetCorePractice.Models.Enums;
using AspNetCorePractice.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCorePractice.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly AspNetCorePracticeDbContext _dbContext;
        public CountryService(AspNetCorePracticeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<CountryDto> GetCountries()
        {
            return _dbContext.Countries.Select(c => new CountryDto { Id = c.Id, Name = c.Name }).ToList();
        }

        public CountryDto GetCountryById(int countryId)
        {
            var country = _dbContext.Countries.FirstOrDefault(c => c.Id == countryId);

            if (country == null) return null;

            return new CountryDto() { Id = country.Id, Name = country.Name };
        }

    }
}
