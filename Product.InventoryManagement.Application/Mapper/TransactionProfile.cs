using AutoMapper;
using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.Application.Features.InventoryTransaction.Commands.CreateTransaction;
using Product.InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Mapper
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<InventoryTransaction, InventoryTransactionDto>().ReverseMap();
            CreateMap<CreateTransactionCommand, InventoryTransaction>();
        }
    }
}
