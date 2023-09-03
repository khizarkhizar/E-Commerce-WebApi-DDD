using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Azure;
using Domain.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Application.Dto;
using WebApplication2.Application.Services; 
namespace WebApplication2.Controllers
{
    [Route("/api")]
    public class  CategoryController : ControllerBase
    {
        private readonly CategoriesService _service;
        private readonly ILogger<CategoriesService> _logger;

        public  CategoryController(ILogger<CategoriesService> logger
            , CategoriesService service)
        {
            _service = service;
            _logger = logger;
        }
  

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var categories = await _service.FetchPage(page, pageSize);
            var basePath = Request.Path;

            return Ok(categories.Item2 );
        }

        [HttpPost]
        [Route("categories")]
        public async Task<IActionResult> CreateCategory(string name, string SubCategory )
        {

            CategoryDtoResponse category =await _service.Create(name, SubCategory);
            return Ok( category)  ;
        }
        [HttpGet("categories/{Id}")]
        public async Task<IActionResult> FetchById(int Id, int page = 1, int pageSize = 5)
        {
            var category =
                await _service.FetchById(Id );
            return Ok(category);
        }

    }
}