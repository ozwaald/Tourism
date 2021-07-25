using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.API.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCompanies()
        {
            return Ok(CompaniesDataStore.Current.Companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);

        }
    }
}
