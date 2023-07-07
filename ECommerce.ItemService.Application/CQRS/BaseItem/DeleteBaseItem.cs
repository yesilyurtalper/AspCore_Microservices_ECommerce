using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class DeleteBaseItem<TModel,TDto> : IRequest<ResponseDto<string>>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public int Id;

    public DeleteBaseItem(int id)
    {
        Id = id;
    }
}

public class DeleteBaseItemHandler<TModel, TDto> :
    IRequestHandler<DeleteBaseItem<TModel, TDto>, ResponseDto<string>>
    where TModel : Domain.BaseItem where TDto : BaseDto

{
    private readonly IBaseItemRepo<TModel> _repo;

    public DeleteBaseItemHandler(IBaseItemRepo<TModel> repo)
    {
        _repo = repo;
    }

    public async Task<ResponseDto<string>> Handle(DeleteBaseItem<TModel, TDto> command, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto<string>();

        if (command.Id == 0)
            throw new BadRequestException("Invalid input for Id");

        var model = await _repo.GetByIdAsync(command.Id);
        if (model == null)
            throw new NotFoundException(typeof(TModel).Name, command.Id);

        await _repo.DeleteAsync(model);
        _response.IsSuccess = true;

        return _response;
    }
}