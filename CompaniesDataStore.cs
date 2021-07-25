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
                    Description = "Flame tours company, created in 2000.",
                    TourPackages = new List<TourPackageDTO>()
                    {
                        new TourPackageDTO()
                        {
                            Id = 1,
                            Name = "Business event in Baku Convention Center",
                            Description = "A flexible scale event from 100 pax to 3000 pax"
                        },
                        new TourPackageDTO()
                        {
                            Id = 2,
                            Name = "Exhibiton at Expo Center",
                            Description = "Possibility to exhibit at Expo Center on a chosen exhibiton."
                        }
                    }
                    
                },
                new CompanyDTO()
                {
                    Id = 2,
                    Name = "Falcon Travel",
                    CompanyType = CompanyType.Leasure,
                    Description = "Doing mostly hunting travel.",
                    TourPackages = new List<TourPackageDTO>()
                    {
                        new TourPackageDTO()
                        {
                            Id = 3,
                            Name = "Fishing tour",
                            Description = "3 full days fishing with camping."
                        },
                        new TourPackageDTO()
                        {
                            Id = 4,
                            Name = "Hunting",
                            Description = "Duck hunting "
                        }
                    }
                },
                new CompanyDTO()
                {
                    Id = 3,
                    Name = "Millenium Travel",
                    CompanyType = CompanyType.TravelAgent,
                    Description = "Have big turnover.",
                    TourPackages = new List<TourPackageDTO>()
                    {
                        new TourPackageDTO()
                        {
                            Id = 5,
                            Name = "Antalya trip",
                            Description = "Family package to Antalya with rafting and boat tours."
                        },
                        new TourPackageDTO()
                        {
                            Id = 6,
                            Name = "Experience Greece",
                            Description = "1 week tour in Greece"
                        },
                        new TourPackageDTO()
                        {
                            Id = 7,
                            Name = "Travel to Bali",
                            Description = "1 week package for couples to Bali."
                        }
                    }
                }
            };
        }
    }
}
