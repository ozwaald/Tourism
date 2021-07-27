using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.API.Models;

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

        [HttpGet("{id}", Name = "GetTourPackage")]
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

        [HttpPost]
        public IActionResult CreateTourPackage(int companyId, 
                                              [FromBody] TourPackageForCreationDTO tourPackage)
        {
            if (tourPackage.Description == tourPackage.Name)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different from the name. Please make amendments");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == companyId);

            if (company == null)
            {
                return NotFound();
            }

            //demo

            var maxTourPackageId = CompaniesDataStore.Current.Companies.SelectMany(c => c.TourPackages).Max(p => p.Id);

            var finalTourPackage = new TourPackageDTO()
            {
                Id = ++maxTourPackageId,
                Name = tourPackage.Name,
                Description = tourPackage.Description
            };

            company.TourPackages.Add(finalTourPackage);

            return CreatedAtRoute(
                "GetTourPackage",
                new { companyId, id = finalTourPackage.Id },
                finalTourPackage);
        }
    }
}
