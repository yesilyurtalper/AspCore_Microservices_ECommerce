using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class GetAllBaseItems<TModel, TDto> : IRequest<ResponseDto>
        where TModel : Domain.BaseItem where TDto : BaseDto
{
}

public class GetAllBaseItemsHandler<TModel, TDto> :
    IRequestHandler<GetAllBaseItems<TModel, TDto>, ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    private IBaseItemRepo<TModel> _repo;
    private IMapper _mapper;

    public GetAllBaseItemsHandler(IBaseItemRepo<TModel> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ResponseDto> Handle(GetAllBaseItems<TModel, TDto> request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto();
        var models = await _repo.GetAllAsync();
        var dtos = _mapper.Map<List<TDto>>(models);
        _response.Result = dtos;
        _response.IsSuccess = true;
        return _response;
    }
}
