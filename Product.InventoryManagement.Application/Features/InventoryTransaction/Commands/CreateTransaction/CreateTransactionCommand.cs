using MediatR;
using Product.InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Features.InventoryTransaction.Commands.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public int UnitsAdded { get; set; } = 0;
        public int UnitsRemoved { get; set; } = 0;
        public string Reason { get; set; } = string.Empty;
    }
}
