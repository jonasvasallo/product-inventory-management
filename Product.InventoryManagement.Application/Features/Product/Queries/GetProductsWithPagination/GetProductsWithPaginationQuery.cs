using MediatR;
using Product.InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Features.Product.Queries.GetProductsWithPagination
{
    public class GetProductsWithPaginationQuery : PaginationRequest, IRequest<PaginationResult<Domain.Entities.Product>>
    {
    }
}
