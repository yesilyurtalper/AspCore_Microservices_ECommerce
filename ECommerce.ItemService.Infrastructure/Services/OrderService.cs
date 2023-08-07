using ECommerce.ItemService.Application.Contracts;
using ECommerce.ItemService.Application.DTOs;

namespace ECommerce.ItemService.Infrastructure.Services;

internal class OrderService : IOrderService
{

    public Task<ResponseDto<string>> MakeOrderAsync()
    {
        throw new NotImplementedException();
    }
}
