using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.Category;

public class GetCategoriesOutOfByBrandId : IRequest<ResponseDto<List<BaseDto>>>
{
    internal readonly int _id;
    public GetCategoriesOutOfByBrandId(int id)
    {
        _id = id;
    }
}

public class GetCategoriesOutOfByBrandIdHandler : IRequestHandler<GetCategoriesOutOfByBrandId, ResponseDto<List<BaseDto>>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepo _repo;

    public GetCategoriesOutOfByBrandIdHandler(ICategoryRepo repo, IMapper mapper)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ResponseDto<List<BaseDto>>> Handle(GetCategoriesOutOfByBrandId request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto<List<BaseDto>>();
        var models = await _repo.GetCategoriesOutOfBrandIdAsync(request._id);
        var dtos = _mapper.Map<List<BaseDto>>(models);
        _response.Data = dtos;
        _response.IsSuccess = true;

        return _response;
    }
}
