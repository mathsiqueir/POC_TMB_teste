using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POC_TMB.Data;
using POC_TMB.Dto;
using POC_TMB.Models;
using POC_TMB.Services;

namespace POC_TMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderInterface _orderInterface;

        public OrdersController(IOrderInterface orderInterface)
        {
            _orderInterface = orderInterface;
        }        

        [HttpPost("/orders")]
        public async Task<ActionResult<OrderModel>> CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = await _orderInterface.CreateOrderAsync(createOrderDto);
            return Ok(order);
            
        }
        [HttpGet("/orders")]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetAllOrders()
        {
            var orders = await _orderInterface.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("/orders/{id}")]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrderById(Guid id)
        {
            var orders = await _orderInterface.GetOrderByIdAsync(id);
            return Ok(orders);
        }
    }
}
