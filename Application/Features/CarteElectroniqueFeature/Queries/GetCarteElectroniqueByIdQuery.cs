using Application.Interfaces;
using Application.Setting;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CarteElectroniqueFeature.Queries
{
    public class GetCarteElectroniqueByIdQuery : IRequest<ResponseHttp>
    {
        public Guid Id { get; set; }

        public GetCarteElectroniqueByIdQuery(Guid id)
        {
            Id = id;
        }

        public class GetNavigatorByIdQueryHandler : IRequestHandler<GetCarteElectroniqueByIdQuery, ResponseHttp>
        {
            private readonly IDematContext _trackingContext;

            public GetNavigatorByIdQueryHandler(IDematContext trackingContext)
            {
                _trackingContext = trackingContext;
            }
            public async Task<ResponseHttp> Handle(GetCarteElectroniqueByIdQuery request, CancellationToken cancellationToken)
            {
                var naviagtor = await _trackingContext.CarteElectroniques
                    .Where(x => x.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);
                if (naviagtor == null)
                    return new ResponseHttp()
                    {
                        Resultat = "Not Found",
                        Status = 404,
                        Fail_Messages = "NoT Exist a Carte Electronique with this Id"
                    };
                return new ResponseHttp()
                {
                    Resultat = naviagtor,
                    Status = 200,
                    Fail_Messages = "None"
                };
            }
        }
    }
}
