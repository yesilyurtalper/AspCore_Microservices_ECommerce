using AutoMapper;
using ECommerce.ItemService.Application.Contracts.Persistence;
using ECommerce.ItemService.Application.DTOs;
using MediatR;

namespace ECommerce.ItemService.Application.CQRS.Brand;

public class UpdateBrandCategories : IRequest<ResponseDto>
{
    internal readonly int _id;
    internal readonly List<int> _categoryIds;

    public UpdateBrandCategories(int id, List<int> categoryIds)
    {
        _id = id;
        _categoryIds = categoryIds;
    }
}

public class UpdateBrandCategoriesHandler : IRequestHandler<UpdateBrandCategories, ResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IBrandRepo _repo;

    public UpdateBrandCategoriesHandler(IBrandRepo repo, IMapper mapper)
    {
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ResponseDto> Handle(UpdateBrandCategories request, CancellationToken cancellationToken)
    {
        var _response = new ResponseDto();
        await _repo.UpdateBrandCategoriesAsync(request._id, request._categoryIds);
        await _repo.SaveChangesAsync();
        _response.Result = _mapper.Map<BaseDto>(await _repo.GetByIdAsync(request._id));
        _response.IsSuccess = true;

        return _response;
    }
}
