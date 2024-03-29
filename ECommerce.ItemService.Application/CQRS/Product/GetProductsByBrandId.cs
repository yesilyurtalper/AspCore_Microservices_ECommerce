﻿using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.Product;

public class GetProductsByBrandId : IRequest<ResponseDto<List<ProductDto>>>
{
    internal readonly int _id;
    public GetProductsByBrandId(int id)
    {
        _id = id;
    }
}

public class GetProductsByBrandIdHandler : IRequestHandler<GetProductsByBrandId, ResponseDto<List<ProductDto>>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepo _repo;

    public GetProductsByBrandIdHandler(IProductRepo repo, IMapper mapper)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ResponseDto<List<ProductDto>>> Handle(GetProductsByBrandId request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto<List<ProductDto>>();
        var models = await _repo.GetProductsByBrandIdAsync(request._id);
        var dtos = _mapper.Map<List<ProductDto>>(models);
        _response.Data = dtos;
        _response.IsSuccess = true;

        return _response;
    }
}
