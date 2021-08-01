using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Contracts.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfAvailableTourPackages 
        {
            get
            {
                return TourPackages.Count;
            }
        }
        public ICollection<TourPackageDTO> TourPackages { get; set; } = new List<TourPackageDTO>();
    }
}
