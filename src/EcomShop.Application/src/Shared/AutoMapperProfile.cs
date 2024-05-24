using AutoMapper;
using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.Shared
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Category mappings
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Product mappings
            CreateMap<Product, ProductReadDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // ProductImage mappings
            CreateMap<ProductImage, ProductImageReadDto>();
            CreateMap<ProductImageCreateDto, ProductImage>();
            CreateMap<ProductImageUpdateDto, ProductImage>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Order mappings
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // OrderItem mappings
            CreateMap<OrderedLineItem, OrderedLineItemReadDto>();
            CreateMap<OrderedLineItemCreateDto, OrderedLineItem>();
            CreateMap<OrderedLineItemUpdateDto, OrderedLineItem>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // User mappings
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>().ForMember(user => user.Password, opt => opt.Ignore());
            CreateMap<UserUpdateDto, User>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));



        }
    }
}