using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Features.Product.Queries.GetAllProductsWithDetails
{
    public class GetAllProductsWithDetailsQuery : IRequest<List<Domain.Entities.Product>>
    {
    }
}
