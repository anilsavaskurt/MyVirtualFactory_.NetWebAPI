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
using MyVirtualFactory.Application.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyVirtualFactory.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SubProductTreeController : BaseApiController
    {
        // GET: api/<controller>
      

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        //}

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSubProductTreeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

  
    }
}
