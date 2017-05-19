using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cgap_api.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Tag { get; set; }

        public float Price { get; set; }

        public int RoomID { get; set; }

        [NotMapped]
        public Room Room { get; set; }
    }
}
