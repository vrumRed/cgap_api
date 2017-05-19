using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Models
{
    public class Room
    {
        public int RoomID { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }

        public int DepartmentID { get; set; }

        [NotMapped]
        public Department Department { get; set; }

        [NotMapped]
        public ICollection<Product> Products { get; set; }
    }
}
