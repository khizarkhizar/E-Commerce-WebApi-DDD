using System;
using System.Collections.Generic;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;  
using WebApplication2.Models;
using WebApplication2.Dtos.Responses.Shared;
 
using WebApplication2.Application.BusinessServices;
using Domain.Orders;
using WebApplication2.Application.Services;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApplication2.Application.Dto;

namespace WebApplication2.Controllers
{
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;
        private readonly ILogger<OrderController> _logger;


        public OrderController(ILogger<OrderController> logger
            , OrderService service)
        {
            _service = service;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
         
           
            Tuple<int, List<Order>> orders = await _service.FetchAll();
            if (orders == null)
                return StatusCodeAndDtoWrapper.BuildGeneric(new ErrorDtoResponse("Not Found"), statusCode: 404);

            return Ok( orders.Item2 ) ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersFromItemName(string ItemName)
        {
            var order = await _service.FetchAllFromItemName(ItemName  );
            if (order == null)
                return StatusCodeAndDtoWrapper.BuildGeneric(new ErrorDtoResponse("Not Found"), statusCode: 404);


            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto form)
        {
            var order = await _service.Create(form);
            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return StatusCodeAndDtoWrapper.BuildErrorResponse("Something went wrong");
            }
        }
    }
}