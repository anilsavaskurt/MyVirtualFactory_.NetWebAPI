using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Features.WorkCenters.Commands.CreateWorkCenter;
using MyVirtualFactory.Application.Features.Orders.Queries.GetAllOrders;

namespace MyVirtualFactory.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WorkCenterOperationController : BaseApiController
    {
        // GET: api/<controller>
  

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWorkCenterOperationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
