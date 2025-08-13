using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using System.Security.Cryptography.X509Certificates;

namespace Persistance.Repositories
{
    public class CarteElectroniqueRepository : GenericRepository<CarteElectronique>, ICarteElectroniqueRepository
    {
        public CarteElectroniqueRepository(DematContext context) : base(context)
        {
        }

        public async Task<PagedList<CarteElectronique>> GetAllWithTypesAsync(int? pageNumber, int? pageSize, CancellationToken cancellationToken)
        {
            var query = await _context.CarteElectroniques
                                        .AsQueryable()
                                        .AsNoTracking()
                                        .Where(e => e.IsDeleted == false)
                                        .ToListAsync(cancellationToken);
            int totalRows = query.AsEnumerable().Count();
            var customer = query
           .Skip(pageNumber.HasValue ? (pageNumber.Value - 1) * pageSize.GetValueOrDefault(1) : 0)
           .Take(pageSize.GetValueOrDefault(int.MaxValue)).ToList();

            return new PagedList<CarteElectronique>(customer, totalRows, pageNumber, pageSize);
        }

    }
}
