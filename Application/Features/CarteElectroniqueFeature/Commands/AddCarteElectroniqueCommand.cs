
using Application.Features.CarteElectroniqueFeature.Dtos;
using Application.Interfaces;
using Application.Setting;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarteElectroniqueFeature.Commands
{
    public record AddCarteElectroniqueCommand(
        string name,
        string companyName,
        string description,
        string price,
        string image,
        string quantityinstock)
        : IRequest<ResponseHttp>
    {
        public class AddCarteElectroniqueCommandHandler : IRequestHandler<AddCarteElectroniqueCommand, ResponseHttp>
        {
            private readonly ICarteElectroniqueRepository CarteElectroniqueRepository;
            private readonly IMapper _mapper;

            public AddCarteElectroniqueCommandHandler(ICarteElectroniqueRepository CarteElectroniqueRepository, IMapper mapper)
            {
                this.CarteElectroniqueRepository = CarteElectroniqueRepository;
                _mapper = mapper;
            }

            public async Task<ResponseHttp> Handle(AddCarteElectroniqueCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var carteelectronique = _mapper.Map<CarteElectronique>(request);

                    carteelectronique = await CarteElectroniqueRepository.Post(carteelectronique);
                    await CarteElectroniqueRepository.SaveChange(cancellationToken);

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