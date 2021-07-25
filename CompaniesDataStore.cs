using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.API.Models;

namespace Tourism.API
{
    public class CompaniesDataStore
    {
        public static CompaniesDataStore Current { get; } = new CompaniesDataStore();
        public List<CompanyDTO> Companies { get; set; }

        public CompaniesDataStore()
        {
            Companies = new List<CompanyDTO>
            {
                new CompanyDTO()
                {
                    Id = 1,
                    Name = "Flame Tours",
                    CompanyType = CompanyType.MICE,
                    Description = "Flame tours company, created in 2000."
                },
                new CompanyDTO()
                {
                    Id = 2,
                    Name = "Falcon Travel",
                    CompanyType = CompanyType.Leasure,
                    Description = "Doing mostly hunting travel."
                },
                new CompanyDTO()
                {
                    Id = 3,
                    Name = "Millenium",
                    CompanyType = CompanyType.TravelAgent,
                    Description = "Have big turnover."
                }
            };
        }
    }
}
