using Application.Features.CarteElectroniqueFeature.Commands;
using Application.Features.CarteElectroniqueFeature.Queries;
using Application.Features.CarteElectroniqueFeature.Validators;
using Application.Features.CustomerFeatures.Validators;
using Application.Features.TestFeature.Queries;
using Application.Setting;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/carteElectronique")]
    [ApiController]
    public class CarteElectroniqueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarteElectroniqueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Add(AddCarteElectroniqueCommand cmd)
        {
            try
            {
                ResponseHttp AddCustomerResult;
                AddCarteElectroniqueCommandNewValidator validator = new();

                AddCustomerResult = validator.Validate(new ValidationContext<AddCarteElectroniqueCommand>(cmd));

                if (AddCustomerResult.Status == StatusCodes.Status400BadRequest)
                {
                    return BadRequest(AddCustomerResult);
                }
                AddCustomerResult = await _mediator.Send(cmd);


                return Ok(AddCustomerResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update([FromBody] UpdateCarteElectroniqueCommand cmd)
        {
            try
            {
                ResponseHttp updateCustomerResult;
                UpdateCarteElectroniqueCommandNewValidator validator = new();

                updateCustomerResult = validator.Validate(new ValidationContext<UpdateCarteElectroniqueCommand>(cmd));

                if (updateCustomerResult.Status == StatusCodes.Status400BadRequest)
                {
                    return BadRequest(updateCustomerResult);
                }

                updateCustomerResult = await _mediator.Send(cmd);

                return Ok(updateCustomerResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var result = await _mediator.Send(new Application.Features.CarteElectroniqueFeature.Commands.DeleteCarteElectroniqueCommand(id));
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get(Guid id)
        {
            GetCarteElectroniqueByIdNewQuery qr = new(id);
            var result = await _mediator.Send(qr);

            return Ok(result);
        }
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get(int? pageNumber, int? pageSize)
        {
            var result = await _mediator.Send(new GetAllCarteElectroniqueNewQuery(pageNumber, pageSize));

            return Ok(result);
        }

    }
}
