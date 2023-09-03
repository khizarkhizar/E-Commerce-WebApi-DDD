using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApplication2.Dtos.Responses.Shared;  
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using WebApplication2.Models;
using System.Text.Json;
using System.Text.Json.Serialization; 
using WebApplication2.Application.BusinessServices;
using Domain.Items;
using WebApplication2.Dto;
using Domain.Addresses;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("/api/Items")]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly  ItemService _service;
        private readonly ILogger<ItemController> _logger;
       
        public int PageSize = 4;
 


        public ItemController( 
                              ItemService service, ILogger<ItemController> logger)
        {
            _logger = logger;
            _service = service; 
      
        }


        [HttpGet("")]
        [ActionName(nameof(Index))]
        public async Task<IActionResult> Index()
        {
            var item = await _service.FetchAll();


            return Ok(item);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ItemRequestDto dto  )
        { 
            var itm = new Item(dto.ItemNme,dto.ItemDesc,dto.Brnd,dto.Price,dto.Rvew,dto.Stock,dto.CategoryId);

            await _service.Create(itm);
            return Ok();
        }
 

        [HttpGet("Item/{Id}")]
        public async Task<IActionResult> FetchById(int Id, int page = 1, int pageSize = 5)
        {
            var item =
                await _service.FetchById(Id);
            return Ok(item);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteById(int Id, int page = 1, int pageSize = 5)
        {
            var item =
                await _service.Delete(Id);
            return Ok(item);
        }

    }
}