﻿using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class AddBrandCategories : IRequest<ResponseDto<BaseDto>>
{
    internal readonly int _id;
    internal readonly List<int> _categoryIds;

    public AddBrandCategories(int id, List<int> categoryIds)
    {
        _id = id;
        _categoryIds = categoryIds;
    }
}

public class AddBrandCategoriesHandler : IRequestHandler<AddBrandCategories, ResponseDto<BaseDto>>
{
    private readonly IMapper _mapper;
    private readonly IBrandRepo _repo;

    public AddBrandCategoriesHandler(IBrandRepo repo, IMapper mapper)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ResponseDto<BaseDto>> Handle(AddBrandCategories request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto<BaseDto>();
        await _repo.AddBrandCategoriesAsync(request._id, request._categoryIds);
        _response.Data = _mapper.Map<BaseDto>(await _repo.GetByIdAsync(request._id));
        _response.IsSuccess = true;

        return _response;
    }
}
