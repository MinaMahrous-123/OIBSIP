using AutoMapper;
using BLL.Model;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Ingredients, IngredientsDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItems, OrderItemsDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<InventoryTransactions, InventoryTransactionsDTO>().ReverseMap();
            CreateMap<OrderItemVegetables, OrderItemVegetablesDTO>().ReverseMap();
        }
    }
}
