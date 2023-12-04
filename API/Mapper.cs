using AutoMapper;
using DTO;
using Entities;

namespace API
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Order, OrderReturnDTO>().ReverseMap();
            CreateMap<OrderItemDTO,OrderItem >().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDTO,Order>().ReverseMap();
            CreateMap<Product, ProductsDTO>().ForMember(i => i.Name,
               opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
