using AutoMapper;
using DTO;
using Entities;
using System.Runtime;

namespace API
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>();
        }
    }
}
