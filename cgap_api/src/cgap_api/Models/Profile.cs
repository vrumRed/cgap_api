using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }

        public string Name { get; set; }

        public bool Send { get; set; }

        public bool Receive { get; set; }

        public bool Audit { get; set; }

        [NotMapped]
        public ICollection<User> Users { get; set; }
    }
}
