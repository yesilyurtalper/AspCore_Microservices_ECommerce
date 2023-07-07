using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class GetProductsByCategoryId : IRequest<ResponseDto<List<ProductDto>>>
{
    internal readonly int _id;
    public GetProductsByCategoryId(int id)
    {
        _id = id;
    }
}

public class GetProductsByCategoryIdHandler : IRequestHandler<GetProductsByCategoryId, ResponseDto<List<ProductDto>>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepo _repo;

    public GetProductsByCategoryIdHandler(IProductRepo repo, IMapper mapper)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ResponseDto<List<ProductDto>>> Handle(GetProductsByCategoryId request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto<List<ProductDto>>();
        var models = await _repo.GetProductsByCategoryIdAsync(request._id);
        var dtos = _mapper.Map<List<ProductDto>>(models);
        _response.Data = dtos;
        _response.IsSuccess = true;

        return _response;
    }
}
