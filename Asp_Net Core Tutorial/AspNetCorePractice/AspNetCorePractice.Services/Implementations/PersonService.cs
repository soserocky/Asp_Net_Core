using AspNetCorePractice.Data.DBContext;
using AspNetCorePractice.Models.DTOs;
using AspNetCorePractice.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AspNetCorePractice.Services.Implementations
{
    public class PersonService : IPersonsService
    {
        private readonly AspNetCorePracticeDbContext _dbContext;
        public PersonService(AspNetCorePracticeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<PersonDto> GetPersons()
        {
            return _dbContext.Persons.Select(p => new PersonDto { Id = p.Id, Name = p.Name }).ToList();
        }

        public IEnumerable<PersonDto> GetPersonsByCountry(int countryId)
        {
            var persons = _dbContext.Persons.Where(c => c.Country == countryId);

            if (persons == null || !persons.Any()) return null;

            return persons.Select(p => new PersonDto() { Id = p.Id, Name = p.Name }).ToList();
        }

        public IEnumerable<PersonDto> GetPersonsByGender(int genderId)
        {
            var persons = _dbContext.Persons.Where(c => c.Gender == genderId);

            if (persons == null || !persons.Any()) return null;

            return persons.Select(p => new PersonDto() { Id = p.Id, Name = p.Name }).ToList();
        }
    }
}
