using Microsoft.AspNetCore.Mvc;
using POC_TMB.Dto;
using POC_TMB.Models;

namespace POC_TMB.Services
{
    public interface IOrderInterface
    {
        Task<IEnumerable<OrderModel>> GetAllOrdersAsync();
        Task<OrderModel> GetOrderByIdAsync(Guid id);
        Task<OrderModel> CreateOrderAsync(CreateOrderDto orderDto);
        Task<OrderModel> UpdateOrderAsync(Guid id, UpdateOrderDto orderDto);
        Task<bool> DeleteOrderAsync(Guid id);
    }
}
