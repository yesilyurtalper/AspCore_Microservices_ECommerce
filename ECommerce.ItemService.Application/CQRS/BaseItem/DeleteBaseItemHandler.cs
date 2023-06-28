using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class DeleteBaseItemHandler<TModel,TDto> : 
    IRequestHandler<DeleteBaseItem<TModel,TDto>, ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto

{
    private readonly IRepository<TModel> _repo;
    private readonly IMapper _mapper;

    public DeleteBaseItemHandler(IRepository<TModel> repo,
        IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ResponseDto> Handle(DeleteBaseItem<TModel,TDto> command, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto();

        if (command.Id == 0)
            throw new BadRequestException("Invalid input for Id");

        var model = await _repo.GetByIdAsync(command.Id);
        if (model == null)
            throw new NotFoundException(typeof(TModel).Name, command.Id);

        await _repo.DeleteAsync(model);
        await _repo.SaveChangesAsync();
        _response.IsSuccess = true;

        return _response;
    }
}
