using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class GetBaseItemById<TModel,TDto> : IRequest<ResponseDto<TDto>>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public int Id { get; set; }
    public GetBaseItemById(int id)
    {
        Id = id;
    }
}

public class GetBaseItemByIdHandler<TModel, TDto> :
        IRequestHandler<GetBaseItemById<TModel, TDto>, ResponseDto<TDto>>
        where TModel : Domain.BaseItem where TDto : BaseDto
{
    private readonly IBaseItemRepo<TModel> _repo;
    private readonly IMapper _mapper;

    public GetBaseItemByIdHandler(IBaseItemRepo<TModel> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<ResponseDto<TDto>> Handle(GetBaseItemById<TModel, TDto> request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto<TDto>();

        if (request.Id == 0)
            throw new BadRequestException("Invalid input for Id");

        var model = await _repo.GetByIdAsync(request.Id);
        if (model == null)
            throw new NotFoundException(typeof(TModel).Name, request.Id);
        else
        {
            _response.IsSuccess = true;
            var dto = _mapper.Map<TDto>(model);
            _response.Data = dto;
        }

        return _response;
    }
}
