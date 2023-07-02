using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class GetBaseItemByName<TModel,TDto> : IRequest<ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    public string Name { get; set; }
    public GetBaseItemByName(string name)
    {
        Name = name;
    }
}

public class GetBaseItemByNameHandler<TModel, TDto> :
    IRequestHandler<GetBaseItemByName<TModel, TDto>, ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    private IBaseItemRepo<TModel> _repo;
    private IMapper _mapper;

    public GetBaseItemByNameHandler(IBaseItemRepo<TModel> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ResponseDto> Handle(GetBaseItemByName<TModel, TDto> request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto();

        if (string.IsNullOrEmpty(request.Name))
            throw new BadRequestException("Invalid input for Name");

        var model = await _repo.GetByNameAsync(request.Name);
        if (model == null)
            throw new NotFoundException(typeof(TModel).Name, request.Name);
        else
        {
            _response.IsSuccess = true;
            var dto = _mapper.Map<TDto>(model);
            _response.Result = dto;
        }

        return _response;
    }
}
