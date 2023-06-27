using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class CreateBaseItemHandler<TModel, TDto> : IRequestHandler<CreateBaseItem<TDto>, ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto

{
    private readonly IRepository<TModel> _repo;
    private readonly IMapper _mapper;

    public CreateBaseItemHandler(IRepository<TModel> repo,
        IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ResponseDto> Handle(CreateBaseItem<TDto> command, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto();

        var model = await _repo.GetByNameAsync(command._dto.Name);
        if (model != null)
            throw new BadRequestException($"{nameof(TModel)} with name = {command._dto.Name} already exists!" );

        model = _mapper.Map<TModel>(command._dto);
        await _repo.CreateAsync(model);
        await _repo.SaveChangesAsync();
        _response.Result = _mapper.Map<TDto>(model);
        _response.IsSuccess = true;

        return _response;
    }
}
