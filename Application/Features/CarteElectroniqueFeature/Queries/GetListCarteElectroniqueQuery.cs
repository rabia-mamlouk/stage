using Application.Interfaces;
using Application.Setting;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CarteElectroniqueFeature.Queries
{
    public class GetListCarteElectroniqueQuery : IRequest<ResponseHttp>
    {
        public class GetListCarteElectroniqueQueryHandler : IRequestHandler<GetListCarteElectroniqueQuery, ResponseHttp>
        {
            private readonly IDematContext _dematContext;

            public GetListCarteElectroniqueQueryHandler(IDematContext dematContext)
            {
                _dematContext = dematContext;
            }
            public async Task<ResponseHttp> Handle(GetListCarteElectroniqueQuery request, CancellationToken cancellationToken)
            {
                var carteelectroniques = await _dematContext.CarteElectroniques.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);
                return new ResponseHttp
                {
                    Status = 200,
                    Fail_Messages = "None",
                    Resultat = new
                    {
                        CarteElectroniques = carteelectroniques
                    }
                };
            }
        }
    }
}
