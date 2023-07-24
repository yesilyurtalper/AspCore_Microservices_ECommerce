using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class UpdateBaseItem<TModel,TDto> : IRequest<ResponseDto<TDto>> 
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public TDto _dto;

    public UpdateBaseItem(TDto dto)
    {
        _dto = dto;
    }
}

public class UpdateBaseItemHandler<TModel, TDto> :
    IRequestHandler<UpdateBaseItem<TModel, TDto>, ResponseDto<TDto>>
    where TModel : Domain.BaseItem where TDto : BaseDto

{
    private readonly IBaseItemRepo<TModel> _repo;
    private readonly IMapper _mapper;

    public UpdateBaseItemHandler(IBaseItemRepo<TModel> repo,IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ResponseDto<TDto>> Handle(UpdateBaseItem<TModel, TDto> command, CancellationToken cancellationToken)
    {
        var dto = command._dto;
        var _response = new ResponseDto<TDto>();

        if (dto == null || dto.Id == 0)
            throw new BadRequestException("No input or invalid input for Id");

        var model = await _repo.GetByIdAsync(dto.Id);
        if (model == null)
            throw new NotFoundException(typeof(TModel).Name, dto.Id);

        var existing = await _repo.GetByNameAsync(dto.Name);
        if (existing != null && model.Id != existing.Id)
            throw new BadRequestException($"{typeof(TModel).Name} with name = {command._dto.Name} already exists!");

        _mapper.Map(dto, model);
        await _repo.UpdateAsync(model);
        _response.Data = _mapper.Map<TDto>(model);
        _response.IsSuccess = true;

        return _response;
    }
}