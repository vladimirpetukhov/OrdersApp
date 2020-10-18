using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.API.Data;
using Server.API.Dtos.Categories;
using Server.API.Helpers;
using Server.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.API.Controllers
{
    [AllowAnonymous]
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category,int> _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryController(IRepository<Category,int> categoryRepo,IMapper mapper)
        {
            this._categoryRepo = categoryRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("categories",Name ="GetCategories")]
        public async Task<IActionResult> GetCategories([FromQuery] PaginationParams paginationParams)
        {
            var categoriesForResponse = new List<CategoryListForResponse>();
            try
            {
                var categories = await this._categoryRepo.AllPaged(paginationParams);
                categoriesForResponse = this._mapper.Map<List<CategoryListForResponse>>(categories);
                Response.AddPagination(categories.CurrentPage, categories.PageSize, categories.TotalCount, categories.TotalPages);
            }
            catch (Exception)
            {

                throw;
            }
            
            return Ok(categoriesForResponse);
        }

        //[Authorize(Policy = "ModeratePhotoRole")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("create", Name ="Createcategory")]
        public async Task<IActionResult> Create([FromForm]CategoryListForResponse model)
        {
            if (model == null)
            {
                return BadRequest(model);
            }

            try
            {

                var category = this._mapper.Map<Category>(model);
                await this._categoryRepo.AddAsync(category);
                await this._categoryRepo.SaveChangesAsync();
                 //this._categoryRepo.Dispose();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
