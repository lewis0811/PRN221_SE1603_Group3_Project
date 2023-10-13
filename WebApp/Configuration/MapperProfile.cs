using AutoMapper;
using Domain.Entities;
using WebApp.ViewModels;

namespace WebApp.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Staff, StaffVM>().ReverseMap();
            CreateMap<LaundryStore, LaundryStoreVM>().ReverseMap();
            CreateMap<Service, ServiceVM>().ReverseMap();
            CreateMap<StoreService, StoreServiceVM>().ReverseMap();
            CreateMap<Shipping, ShippingVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailVM>().ReverseMap();

        }
    }
}
