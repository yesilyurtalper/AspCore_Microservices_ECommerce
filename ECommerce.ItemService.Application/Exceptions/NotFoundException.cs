using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ItemService.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) : base($"{name} with ID={key} was not found")
    {   
    }

    public NotFoundException(string message) : base(message)
    {
    }
}
