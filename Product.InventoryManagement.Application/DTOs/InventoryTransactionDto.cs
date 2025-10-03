using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.DTOs
{
    public class InventoryTransactionDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int UnitsAdded { get; set; } = 0;
        public int UnitsRemoved { get; set; } = 0;
        public string UserId { get; set; } = string.Empty;
    }
}
