using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarteElectronique : Entity
    {
        public string  Name { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string QuantityInStock { get; set; }
    }
}
