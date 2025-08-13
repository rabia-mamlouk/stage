using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICarteElectroniqueRepository : IGenericRepository<CarteElectronique>
    {
        Task<PagedList<CarteElectronique>> GetAllWithTypesAsync(int? pageNumber, int? pageSize, CancellationToken cancellationToken);
    }
}
