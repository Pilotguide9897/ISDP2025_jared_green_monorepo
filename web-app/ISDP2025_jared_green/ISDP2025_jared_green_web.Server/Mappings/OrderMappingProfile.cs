﻿    using AutoMapper;
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

            CreateMap<dtoOrderItemCreation, Txnitem>()
                .ForMember(dest => dest.Item, opt => opt.Ignore())
                .ForMember(dest => dest.Txn, opt => opt.Ignore());

            CreateMap<Inventory, dtoInventory>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));

            CreateMap<Txn, dtoDelivery>().ForMember(dest => dest.OrderSite, opt => opt.MapFrom(src => src.SiteIdfromNavigation));

            // No need for special configuring.
            CreateMap<Item, dtoItem>();

            CreateMap<Site, dtoSite>();
        }
    }
}
