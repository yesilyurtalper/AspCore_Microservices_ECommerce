using ECommerce.ItemService.Application.Contracts;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Infrastructure.Constants;

namespace ECommerce.ItemService.Infrastructure.Services;

internal class OrderService : IOrderService
{
    
    private readonly IHttpClientFactory _httpClientFactory;

    public OrderService(IHttpClientFactory httpFac)
    {
        _httpClientFactory = httpFac;
    }

    public async Task<ResponseDto<string>> MakeOrderAsync()
    {
        var httpClient = _httpClientFactory.CreateClient(InfraConstants.OrderAPIClient);
        var response = await httpClient.SendAsync(new HttpRequestMessage());
        throw new NotImplementedException();
    }
}
