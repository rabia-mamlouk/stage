using Application.Interfaces;
using Application.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarteElectroniqueFeature.Commands
{
    public record DeleteCarteElectroniqueCommand(
        Guid CarteElectroniqueId
        )
        : IRequest<ResponseHttp>
    {

        public class DeleteCarteElectroniqueCommandHandler : IRequestHandler<DeleteCarteElectroniqueCommand, ResponseHttp>
        {
            private readonly ICarteElectroniqueRepository carteelectroniqueRepository;
            public DeleteCarteElectroniqueCommandHandler(ICarteElectroniqueRepository carteelectroniqueRepository)
            {
                this.carteelectroniqueRepository = carteelectroniqueRepository;
            }

            public async Task<ResponseHttp> Handle(DeleteCarteElectroniqueCommand request, CancellationToken cancellationToken)
            {
                var carteelectronique = await carteelectroniqueRepository.GetById(request.CarteElectroniqueId);

                if (carteelectronique == null)
                {
                    return new ResponseHttp
                    {
                        Fail_Messages = "No carte electronique found",
                        Status = StatusCodes.Status400BadRequest,
                    };
                }

                await carteelectroniqueRepository.SoftDelete(request.CarteElectroniqueId);
                await carteelectroniqueRepository.SaveChange(cancellationToken);

                return new ResponseHttp
                {
                    Status = StatusCodes.Status200OK,
                };
            }
        }
    }
}