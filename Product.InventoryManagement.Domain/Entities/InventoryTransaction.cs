using Product.InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Domain.Entities
{
    public class InventoryTransaction : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UnitsAdded { get; set; } = 0;
        public int UnitsRemoved { get; set; } = 0;
        public string Reason { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

    }
}
