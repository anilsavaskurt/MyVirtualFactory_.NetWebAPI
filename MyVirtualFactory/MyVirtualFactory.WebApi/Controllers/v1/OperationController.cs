using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Features.Operations.Commands.CreateOperation;
using MyVirtualFactory.Application.Features.Orders.Queries.GetAllOrders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyVirtualFactory.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OperationController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllOperationsQuery()));
        }
        // POST api/<controller>

        [HttpPost]
        public async Task<IActionResult> Post(CreateOperationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        
    }
}
