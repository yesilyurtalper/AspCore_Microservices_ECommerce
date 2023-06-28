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

namespace ECommerce.ItemService.Application.CQRS.BaseItem
{
    public class GetByIdHandler<TModel, TDto> :
        IRequestHandler<GetById<TModel, TDto>, ResponseDto>
        where TModel : Domain.BaseItem where TDto : BaseDto
    {
        private IRepository<TModel> _repo;
        private IMapper _mapper;

        public GetByIdHandler(IRepository<TModel> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ResponseDto> Handle(GetById<TModel,TDto> request, CancellationToken cancellationToken)
        {
            var _response = new ResponseDto();

            if (request.Id == 0)
                throw new BadRequestException("Invalid input for Id");

            var model = await _repo.GetByIdAsync(request.Id);
            if (model == null)
                throw new NotFoundException(typeof(TModel).Name, request.Id);
            else
            {
                _response.IsSuccess = true;
                var dto = _mapper.Map<TDto>(model);
                _response.Result = dto;
            }

            return _response;
        }
    }
}
