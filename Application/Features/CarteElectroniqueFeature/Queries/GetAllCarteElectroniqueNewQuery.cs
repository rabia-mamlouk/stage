using Application.Features.CarteElectroniqueFeature.Dtos;
using Application.Interfaces;
using Application.Setting;
using AutoMapper;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarteElectroniqueFeature.Queries
{
    public record GetAllCarteElectroniqueNewQuery(int? pageNumber, int? pageSize) : IRequest<ResponseHttp>
    {
        public class GetAllCarteElectroniqueNewQueryHandler : IRequestHandler<GetAllCarteElectroniqueNewQuery, ResponseHttp>
        {
            private readonly ICarteElectroniqueRepository carteelectroniqueRepository;
            private readonly IMapper _mapper;

            public GetAllCarteElectroniqueNewQueryHandler(ICarteElectroniqueRepository carteelectroniqueRepository, IMapper mapper)
            {
                this.carteelectroniqueRepository = carteelectroniqueRepository;
                _mapper = mapper;
            }

            public async Task<ResponseHttp> Handle(GetAllCarteElectroniqueNewQuery request, CancellationToken cancellationToken)
            {
                var carteelectronique = await carteelectroniqueRepository.GetAllWithTypesAsync(request.pageNumber, request.pageSize, cancellationToken);

                if (carteelectronique == null)
                    return new ResponseHttp
                    {
                        Fail_Messages = "No carte electronique found !",
                        Status = StatusCodes.Status400BadRequest,
                    };

                var customersToReturn = _mapper.Map<PagedList<CarteElectroniqueDTO>>(carteelectronique);
                return new ResponseHttp
                {
                    Status = 200,
                    Resultat = customersToReturn
                };
            }
        }
    }
}
