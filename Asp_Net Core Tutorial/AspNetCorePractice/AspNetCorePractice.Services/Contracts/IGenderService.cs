using AspNetCorePractice.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCorePractice.Services.Contracts
{
    public interface IGenderService
    {
        IEnumerable<GenderDto> GetGenders();
    }
}
