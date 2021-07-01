using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Features.Products.Commands;
using MyVirtualFactory.Application.Features.Products.Commands.CreateProduct;
using MyVirtualFactory.Application.Features.Products.Commands.DeleteProductById;
using MyVirtualFactory.Application.Features.Products.Commands.UpdateProduct;
using MyVirtualFactory.Application.Features.Products.Queries.GetAllProducts;
using MyVirtualFactory.Application.Features.Products.Queries.GetProductById;
using MyVirtualFactory.Application.Features.WorkCenters.Queries.GetAllWorkCenters;
using MyVirtualFactory.Application.Filters;
using MyVirtualFactory.Application.Features.WorkCenters.Commands.CreateWorkCenter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyVirtualFactory.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WorkCenterController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await Mediator.Send(new GetAllWorkCentersQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWorkCenterCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //[Authorize]
        //public async Task<IActionResult> Put(int id, UpdateProductCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await Mediator.Send(command));
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //[Authorize]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        //}
    }
}
