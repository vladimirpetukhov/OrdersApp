namespace Server.API.Controllers
{

    using Data;
    using Dtos.Product;
    using Models;
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Server.API.Models.DataTable;
    using System.Linq;
    using Server.API.Helpers;
    using Microsoft.AspNetCore.Cors;

  
    [AllowAnonymous]    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product, string> _repository;
        private readonly IMapper _mapper;

        public ProductController(IRepository<Product, string> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> Post(ProductCreateDto dto)
        {
            try
            {
                var product = this._mapper.Map<Product>(dto);
                await this._repository.AddAsync(product);
            }
            catch (Exception Ex)
            {

                throw new ArgumentException();
            }
            return Ok();
        }

        [HttpGet]
        [Route("get-products")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParams productParams)
        {
            var productsToReturn = new List<ProductForListDto>();
            try
            {
                var products = await _repository.GetProducts(productParams);

                foreach (var product in products)
                {
                    var p = _mapper.Map<ProductForListDto>(product);
                    productsToReturn.Add(p);
                };

                Response.AddPagination(products.CurrentPage, products.PageSize,
                products.TotalCount, products.TotalPages);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            

           
            

            return Ok(productsToReturn);
        }
    }
}
