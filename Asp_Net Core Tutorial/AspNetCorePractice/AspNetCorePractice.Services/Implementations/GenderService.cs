using AspNetCorePractice.Data.DBContext;
using AspNetCorePractice.Models.DTOs;
using AspNetCorePractice.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCorePractice.Services.Implementations
{
    public class GenderService : IGenderService
    {
        private readonly AspNetCorePracticeDbContext _dbContext;
        public GenderService(AspNetCorePracticeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<GenderDto> GetGenders()
        {
            return _dbContext.Genders.Select(g => new GenderDto { Id = g.Id, Type = g.Type }).ToList();
        }
    }
}
