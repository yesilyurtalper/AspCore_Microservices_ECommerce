using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class DeleteBaseItem<TModel,TDto> : IRequest<ResponseDto<TDto>>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public int Id;

    public DeleteBaseItem(int id)
    {
        Id = id;
    }
}

public class DeleteBaseItemHandler<TModel, TDto> :
    IRequestHandler<DeleteBaseItem<TModel, TDto>, ResponseDto<TDto>>
    where TModel : Domain.BaseItem where TDto : BaseDto

{
    private readonly IBaseItemRepo<TModel> _repo;
    private readonly ILogger<DeleteBaseItemHandler<TModel, TDto>> _logger;
    private readonly IMapper _mapper;

    public DeleteBaseItemHandler(IBaseItemRepo<TModel> repo,
        ILogger<DeleteBaseItemHandler<TModel, TDto>> logger,
        IMapper mapper)
    {
        _repo = repo;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<ResponseDto<TDto>> Handle(DeleteBaseItem<TModel, TDto> command, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto<TDto>();

        if (command.Id == 0)
            throw new BadRequestException("Invalid input for Id");

        var model = await _repo.GetByIdAsync(command.Id);
        if (model == null)
            throw new NotFoundException(typeof(TModel).Name, command.Id);

        await _repo.DeleteAsync(model);
        _response.Data = _mapper.Map<TDto>(model);
        _response.IsSuccess = true;

        _logger.LogInformation("{@response}", _response);

        return _response;
    }
}