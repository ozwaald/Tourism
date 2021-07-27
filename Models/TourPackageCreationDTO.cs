using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.API.Models
{
    public class TourPackageCreationDTO
    {
        [Required(ErrorMessage = "Please provide the name of the tour package.")]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(200, ErrorMessage = "Please keep the description text between 200 symbols.")]
        public string Description { get; set; }
    }
}
