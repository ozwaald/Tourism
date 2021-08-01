
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Data;
using Tourism.Data.Models;

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

            //var maxTourPackageId = CompaniesDataStore.Current.Companies.SelectMany(c => c.TourPackages).Max(p => p.Id);

            //var finalTourPackage = new TourPackageDTO()
            //{
            //    Id = ++maxTourPackageId,
            //    Name = tourPackage.Name,
            //    Description = tourPackage.Description
            //};

            //company.TourPackages.Add(finalTourPackage);

            //return CreatedAtRoute(
            //    "GetTourPackage",
            //    new { companyId, id = finalTourPackage.Id },
            //    finalTourPackage);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTourPackage(int companyId, int id,
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

            var tourPackageFromStore = company.TourPackages.FirstOrDefault(t => t.Id == id);

            if (tourPackageFromStore == null)
            {
                return NotFound();
            }

            tourPackageFromStore.Name = tourPackage.Name;
            tourPackageFromStore.Description = tourPackage.Description;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult ParticallyUpdateTourPackage(int companyId, int id,
                                                         [FromBody] JsonPatchDocument<TourPackageForUpdateDTO> patchDoc)
        {
            var company = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == companyId);

            if (company == null)
            {
                return NotFound();
            }

            var tourPackageFromStore = company.TourPackages.FirstOrDefault(t => t.Id == id);

            if (tourPackageFromStore == null)
            {
                return NotFound();
            }

            var tourPackageToPatch =
                new TourPackageForUpdateDTO()
                {
                    Name = tourPackageFromStore.Name,
                    Description = tourPackageFromStore.Description
                };

            patchDoc.ApplyTo(tourPackageToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tourPackageToPatch.Description == tourPackageToPatch.Name)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different from the name. Please make amendments");
            }

            if (!TryValidateModel(tourPackageToPatch))
            {
                return BadRequest(ModelState);
            }

            tourPackageFromStore.Name = tourPackageToPatch.Name;
            tourPackageFromStore.Description = tourPackageToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTourPackage(int companyId, int id)
        {
            var company = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == companyId);

            if (company == null)
            {
                return NotFound();
            }

            var tourPackageFromStore = company.TourPackages.FirstOrDefault(t => t.Id == id);

            if (tourPackageFromStore == null)
            {
                return NotFound();
            }

            company.TourPackages.Remove(tourPackageFromStore);

            return NoContent();
        }
    }
}
