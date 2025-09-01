

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using POC_TMB.Data;
using POC_TMB.Dto;
using POC_TMB.Models;
using static POC_TMB.Models.OrderModel;

namespace POC_TMB.Services
{
    public class OrderService : IOrderInterface
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OrderService> _logger;

        public OrderService(AppDbContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            try
            {
                var orders = await _context.Orders.OrderByDescending(o => o.DataCriacao).ToListAsync();

                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os pedidos");
                throw;
            }

        }

        public async Task<OrderModel> GetOrderByIdAsync(Guid id)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

                if (order == null)
                {
                    throw new KeyNotFoundException($"Pedido com ID {id} não encontrado");
                }

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ao buscar peiddo com ID: {OrderId}", id);
                throw;
            }
        }

        public async Task<OrderModel> CreateOrderAsync(CreateOrderDto orderDto)
        {
            try
            {
                var order = new OrderModel()
                {
                    Cliente = orderDto.Cliente,
                    Produto = orderDto.Produto,
                    Valor = orderDto.Valor,
                    Status = OrderStatus.Pendente,
                    DataCriacao = DateTime.UtcNow
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Pedido criado com sucesso. ID:{OrderId}", order.Id);
                return order;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Erro ao criar pedido para cliente: {Cliente}", orderDto.Cliente);
                throw;
            }
        }

        public async Task<OrderModel> UpdateOrderAsync(Guid id, UpdateOrderDto orderDto)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                {
                    return null;
                }

                // Atualizar apenas campos que não estão vazios/nulos
                if (!string.IsNullOrEmpty(orderDto.Cliente))
                    order.Cliente = orderDto.Cliente;

                if (!string.IsNullOrEmpty(orderDto.Produto))
                    order.Produto = orderDto.Produto;

                if (orderDto.Valor > 0)
                    order.Valor = orderDto.Valor;

                if (!string.IsNullOrEmpty(orderDto.Status))
                    order.Status = orderDto.Status;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Pedido atualizado com sucesso. ID: {OrderId}", order.Id);
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar pedido com ID: {OrderId}", id);
                throw;
            }
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                {
                    return false;
                }

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Pedido excluído com sucesso. ID: {OrderId}", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir pedido com ID: {OrderId}", id);
                throw;
            }
        }
    }
}

