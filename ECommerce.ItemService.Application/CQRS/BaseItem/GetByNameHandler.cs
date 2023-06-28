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

public class GetByNameHandler<TModel,TDto> : 
    IRequestHandler<GetByName<TModel,TDto>,ResponseDto>
    where TModel : Domain.BaseItem where TDto : BaseDto
{
    private IRepository<TModel> _repo;
    private IMapper _mapper;

    public GetByNameHandler(IRepository<TModel> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ResponseDto> Handle(GetByName<TModel, TDto> request, CancellationToken cancellationToken)
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
