using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POC_TMB.Data;
using POC_TMB.Dto;
using POC_TMB.Models;

namespace POC_TMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrderById(Guid id)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

                if (order == null)
                {
                    return NotFound("Pedido não encontrado");
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, 
                    new { message = "erro interno do servidor", error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<OrderModel> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var order = new OrderModel
                {
                    Cliente = createOrderDto.Cliente,
                    Produto = createOrderDto.Produto,
                    Valor = createOrderDto.Valor,
                    Status = createOrderDto.Status = "pendente"
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                return order;
                }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new { message = "erro interno ao criar pedido", error = ex.Message });
            }
        }
    }
}
