using Application.Features.CarteElectroniqueFeature.Dtos;
using Application.Interfaces;
using Application.Setting;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarteElectroniqueFeature.Commands
{
    public record UpdateCarteElectroniqueCommand(
       Guid CarteElectroniqueId,
        string name,
        string companyName,
        string description,
        string price,
        string image,
        string quantityinstock)
        : IRequest<ResponseHttp>

    {
        public class UpdateCarteElectroniqueCommandHandler : IRequestHandler<UpdateCarteElectroniqueCommand, ResponseHttp>
        {
            private readonly ICarteElectroniqueRepository carteelectroniqueRepository;
            private readonly IMapper _mapper;

            public UpdateCarteElectroniqueCommandHandler(ICarteElectroniqueRepository carteelectroniqueRepository, IMapper mapper)
            {
                this.carteelectroniqueRepository = carteelectroniqueRepository;
                _mapper = mapper;
            }

            public async Task<ResponseHttp> Handle(UpdateCarteElectroniqueCommand request, CancellationToken cancellationToken)
            {
                CarteElectronique? carteelectronique = await carteelectroniqueRepository.GetById(request.CarteElectroniqueId);

                if (carteelectronique == null)
                {
                    return new ResponseHttp
                    {
                        Resultat = this._mapper.Map<CarteElectroniqueDTO>(carteelectronique),
                        Fail_Messages = "Customer with this Id not found.",
                        Status = StatusCodes.Status400BadRequest,
                    };
                }
                else
                {
                    
                    carteelectronique.Id = request.CarteElectroniqueId;
                    carteelectronique.Name = request.name;
                    carteelectronique.CompanyName = request.companyName;
                    carteelectronique.Description = request.description;
                    carteelectronique.Price = request.price;
                    carteelectronique.Image = request.image;
                    carteelectronique.QuantityInStock = request.quantityinstock;
                    await this.carteelectroniqueRepository.Update(carteelectronique);
                    await this.carteelectroniqueRepository.SaveChange(cancellationToken);

                    var customerToReturn = _mapper.Map<CarteElectroniqueDTO>(carteelectronique);
                    return new ResponseHttp
                    {
                        Resultat = customerToReturn,
                        Status = StatusCodes.Status200OK,
                    };

                }

            }
        }
    }
}
