using ECommerce.ItemService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ItemService.Application.Contracts;

public interface IOrderService
{
    public  Task<ResponseDto<string>> MakeOrderAsync();
}
