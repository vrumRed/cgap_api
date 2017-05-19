using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "The passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string Phone { get; set; }

        [NotMapped]
        public IFormFile Picture { get; set; }

        public string PictureLocale { get; set; }

        public int DepartmentID { get; set; }

        [NotMapped]
        public Department Department { get; set; }

        public int ProfileID { get; set; }

        [NotMapped]
        public Profile Profile { get; set; }
    }
}
