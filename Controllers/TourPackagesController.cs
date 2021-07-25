using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.API.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/[controller]")]
    public class TourPackagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTourPackages(int companyId)
        {
            var company = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == companyId);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company.TourPackages);
        }

        [HttpGet("{id}")]
        public IActionResult GetTourPackage(int companyId, int id)
        {
            var company = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == companyId);

            if (company == null)
            {
                return NotFound();
            }

            var tourPackage = company.TourPackages.FirstOrDefault(t => t.Id == id);

            if (tourPackage == null)
            {
                return NotFound();
            }

            return Ok(tourPackage);
        }
    }
}
