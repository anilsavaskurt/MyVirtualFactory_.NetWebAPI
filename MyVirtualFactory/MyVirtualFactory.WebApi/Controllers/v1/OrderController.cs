using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Features.Orders.Queries.GetOrdersByOrderStatus;
using MyVirtualFactory.Application.Features.Products.Commands.CreateProduct;
using MyVirtualFactory.Domain.Enums;
using MyVirtualFactory.Application.Features.Orders.Queries.GetAllOrders;
using MyVirtualFactory.Application.Features.Orders.Queries.GetCustomersOrders;
using MyVirtualFactory.Application.Features.OrderItems.Queries.GetOrderItemsByOrderId;
using MyVirtualFactory.Application.Features.Products.Commands.ScheduleOrder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyVirtualFactory.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrderController : BaseApiController
    {
  
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("GetOrdersByStatus")]
        public async Task<IActionResult> GetOrdersByStatus(OrderStatus orderStatus)
        {
            return Ok(await Mediator.Send(new GetOrdersByOrderStatusQuery { OrderStatus = orderStatus }));
        }

        [HttpGet("GetOrdersItemsByOrderId")]
        public async Task<IActionResult> GetOrdersItemsByOrderId(int orderId)
        {
            return Ok(await Mediator.Send(new GetOrderItemsByOrderIdQuery { OrderId = orderId}));
        }

        //GETALLORDERS FOR ADMIN
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery { }));
        }

        [HttpGet("GetCustomersOrdersQuery")]
        public async Task<IActionResult> GetCustomersOrdersQuery(string customerId)
        {
            return Ok(await Mediator.Send(new GetCustomersOrdersQuery { CustomerId = customerId }));
        }

        [HttpPost("GetCreatorWorkCenters")]
        public async Task<IActionResult> GetCreatorWorkCenters(ScheduleOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
