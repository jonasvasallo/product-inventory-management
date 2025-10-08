using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.DTOs
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
