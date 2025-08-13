using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarteElectroniqueFeature.Dtos
{
    public class CarteElectroniqueDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string QuantityInStock { get; set; }
    }
}
