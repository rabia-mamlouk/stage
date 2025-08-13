using Application.Features.CarteElectroniqueFeature.Dtos;
using Application.Interfaces;
using Application.Setting;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarteElectroniqueFeature.Queries
{
    public record GetCarteElectroniqueByIdNewQuery(
        Guid CarteElectroniqueId
        ) : IRequest<ResponseHttp>
    {
        public class GetCarteElectroniqueByIdNewQueryHandler : IRequestHandler<GetCarteElectroniqueByIdNewQuery, ResponseHttp>
        {
            private readonly ICarteElectroniqueRepository carteelectroniqueRepository;
            private readonly IMapper _mapper;

            public GetCarteElectroniqueByIdNewQueryHandler(ICarteElectroniqueRepository carteelectroniqueRepository, IMapper mapper)
            {
                this.carteelectroniqueRepository = carteelectroniqueRepository;
                _mapper = mapper;
            }

            public async Task<ResponseHttp> Handle(GetCarteElectroniqueByIdNewQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var carteelectronique = await carteelectroniqueRepository.GetByIdAsync(request.CarteElectroniqueId, cancellationToken);

                    if (carteelectronique == null)
                        return new ResponseHttp()
                        {
                            Status = 404,
                            Fail_Messages = "Carte Electronique not found !"
                        };

                    return new ResponseHttp()
                    {

                        Resultat = _mapper.Map<CarteElectroniqueDTO>(carteelectronique),
                        Status = 200
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseHttp
                    {
                        Fail_Messages = ex.Message,
                        Status = StatusCodes.Status400BadRequest,
                    };

                }

            }
        }
    }
}
