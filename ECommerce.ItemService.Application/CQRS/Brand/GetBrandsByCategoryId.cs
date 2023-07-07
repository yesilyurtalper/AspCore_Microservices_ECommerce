using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class GetBrandsByCategoryId : IRequest<ResponseDto<List<BaseDto>>>
{
    internal readonly int _id;
    public GetBrandsByCategoryId(int id)
    {
        _id = id;
    }
}

public class GetBrandsByCategoryIdHandler : IRequestHandler<GetBrandsByCategoryId, ResponseDto<List<BaseDto>>>
{
    private readonly IMapper _mapper;
    private readonly IBrandRepo _repo;

    public GetBrandsByCategoryIdHandler(IBrandRepo repo, IMapper mapper)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ResponseDto<List<BaseDto>>> Handle(GetBrandsByCategoryId request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto<List<BaseDto>>();
        var models = await _repo.GetBrandsByCategoryIdAsync(request._id);
        var dtos = _mapper.Map<List<BaseDto>>(models);
        _response.Data = dtos;
        _response.IsSuccess = true;

        return _response;
    }
}
