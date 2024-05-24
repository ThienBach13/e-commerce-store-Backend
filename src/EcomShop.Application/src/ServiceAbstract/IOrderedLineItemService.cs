using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Common;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IOrderedLineItemService : IBaseService<OrderedLineItemReadDto, OrderedLineItemCreateDto, OrderedLineItemUpdateDto, QueryOptions>
    {

    }
}