using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using ECommerce.ItemService.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce.ItemService.Application.CQRS.BaseItem;

public class GetAllHandler<TModel, TDto> :
    IRequestHandler<GetAll<TModel, TDto>, ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    private IRepository<TModel> _repo;
    private IMapper _mapper;

    public GetAllHandler(IRepository<TModel> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ResponseDto> Handle(GetAll<TModel, TDto> request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto();
        var models = await _repo.GetAllAsync();
        var dtos = _mapper.Map<List<TDto>>(models);
        _response.Result = dtos;
        _response.IsSuccess = true;
        return _response;
    }
}
