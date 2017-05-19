using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        
        public string Birthdate { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }
        
        public string PictureLocale { get; set; }

        public int DepartmentID { get; set; }

        [NotMapped]
        public Department Department { get; set; }

        public int ProfileID { get; set; }

        [NotMapped]
        public Profile Profile { get; set; }
    }
}
