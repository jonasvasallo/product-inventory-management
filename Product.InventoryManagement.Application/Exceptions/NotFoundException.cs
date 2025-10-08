using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, int id) : base($"{name}{id} was not found.")
        {
            
        }
    }
}
