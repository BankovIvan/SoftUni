using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportDTO09Suppliers, Supplier>();
                //.ForMember(dst => dst.Name, src => src.MapFrom(dto => dto.name))
                //.ForMember(dst => dst.IsImporter, src => src.MapFrom(dto => dto.isImporter));
            this.CreateMap<ImportDTO10Parts, Part>();
            this.CreateMap<ImportDTO11Car, Car>();
            this.CreateMap<ImportDTO12Customer, Customer>();
            this.CreateMap<ImportDTO13Sale, Sale>();

        }
    }
}
