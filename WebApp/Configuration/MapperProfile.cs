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
        }
    }
}
