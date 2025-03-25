    using AutoMapper;
    using ISDP2025_jared_green_web.Server.Models;
    using ISDP2025_jared_green_web.Server.Models.dto;

namespace ISDP2025_jared_green_web.Server.Mappings
{

    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile() 
        {
            // Special Configuration required => ForMember
            CreateMap<Txn, dtoOrder>().ForMember(dest => dest.OrderSite, opt => opt.MapFrom(src => src.SiteIdtoNavigation));

            CreateMap<Txnitem, dtoTxnItem>().ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));

            // No need for special configuring.
            CreateMap<Item, dtoItem>();

            CreateMap<Site, dtoSite>();
        }
    }
}
