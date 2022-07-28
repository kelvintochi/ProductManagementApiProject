using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quality { get; set; }
        public int Price { get; set; }
        public DateTime CreateDate  { get; set; }
    }
}
