using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }
    }
}
