using ECommerce.ItemService.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ItemService.Application.CQRS.BaseItem
{
    public class GetAll<TModel,TDto> : IRequest<ResponseDto>
        where TModel : Domain.BaseItem where TDto : BaseDto
    {
    }
}
