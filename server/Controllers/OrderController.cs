using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.API.Data;
using Server.API.Dtos.Order;
using Server.API.Helpers;
using Server.API.Models;

namespace Server.API.Controllers
{
   
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IRepository<Order, string> _repository;
        private readonly IMapper _mapper;

        public OrderController(IRepository<Order, string> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("get-products")]
        public async Task<IActionResult> GetOrders([FromQuery] OrderParams orderParams)
        {
            var orders = await _repository.GetOrders(orderParams);

            var ordersToReturn = _mapper.Map<IEnumerable<OrderForListDto>>(orders);


            Response.AddPagination(orders.CurrentPage, orders.PageSize,
                orders.TotalCount, orders.TotalPages);

            return Ok(ordersToReturn);
        }
    }
}
