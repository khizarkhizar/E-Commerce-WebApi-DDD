using System.Threading.Tasks; 
using WebApplication2.Models; 
using Microsoft.AspNetCore.Authentication; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;  
using WebApplication2.Dto;
using Azure.Core;
using WebApplication2.Application.Services;

namespace WebApplication2.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class AddressesController : ControllerBase
    { 
        private readonly  AddressesService _service; 
        private readonly ILogger<AddressesController> _logger;
        public AddressesController(ILogger<AddressesController> logger
            , AddressesService service)
        {
            _service = service;
            _logger = logger;
        }

        [Route("addresses")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        { 
            var addresses =
                await _service.FetchPage(  page,
                    pageSize);
      

            return Ok(addresses); 
        }


        [Route("addresses")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrEditAddressDto dto)
        {
            var address = await _service.Create( 
                  dto.Country, dto.City, dto.StreetAddress, dto.ZipCode);


            return Ok(address); 
        }

 
    }
}