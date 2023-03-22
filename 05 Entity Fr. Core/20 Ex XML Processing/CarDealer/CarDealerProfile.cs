using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportDTO09Supplier, Supplier>();
            this.CreateMap<ImportDTO10Part, Part>()
                // Required because DTO SupplierId may be null or missing.
                .ForMember(
                    dst => dst.SupplierId, 
                    opt => opt.MapFrom(
                        src => src.SupplierId!.Value));
            this.CreateMap<ImportDTO11PartCar, PartCar>();
            this.CreateMap<ImportDTO11Car, Car>()
                .ForSourceMember(src => src.PARTS, opt => opt.DoNotValidate());
            this.CreateMap<ImportDTO12Customer, Customer>()
                .ForMember(dst => dst.BirthDate,
                    opt => opt.MapFrom(src => DateTime.Parse(src.BirthDate, CultureInfo.InvariantCulture)));
            this.CreateMap<ImportDTO13Sale, Sale>();

            this.CreateMap<Car, ExportDTO14CarWithDistance>();
            this.CreateMap<Car, ExportDTO15CarBMW>();
            this.CreateMap<Supplier, ExportDTO16LocalSupplier>()
                .ForMember(dst => dst.COUNT,
                    opt => opt.MapFrom(src => src.Parts.Count));
            this.CreateMap<Part, ExportDTO17PartForCar>();
            this.CreateMap<Car, ExportDTO17CarWithParts>()
                .ForMember(dst => dst.PARTS,
                    opt => opt.MapFrom(
                        src => src.PartsCars
                            .Where(pc => pc.CarId == src.Id)
                            .OrderByDescending(pc => pc.Part.Price)
                            .Select(pc => pc.Part)
                            .ToArray()));
            this.CreateMap<Customer, ExportDTO18SalePrices>()
                .ForMember(dst => dst.BoughtCars,
                    opt => opt.MapFrom(src => src.Sales.Count))
                .ForMember(dst => dst.CarPrices,
                    opt => opt.MapFrom(
                        src => src.IsYoungDriver == true ?
                            src.Sales.Select(s => /* ((95 - s.Discount) / 100) * */ (decimal)0.95 * s.Car.PartsCars
                                .Sum(pc => pc.Part.Price) )
                            : src.Sales.Select(s => /* ((100 - s.Discount) / 100) * */ s.Car.PartsCars
                                .Sum(pc => pc.Part.Price))));
            this.CreateMap<Car, ExportDTO19CarData>();
            this.CreateMap<Sale, ExportDTO19SaleAndDiscount>()
                .ForMember(dst => dst.CAR,
                    opt => opt.MapFrom(src => src.Car))
                .ForMember(dst => dst.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dst => dst.FullPrice,
                    opt => opt.MapFrom(src => src.Car.PartsCars
                        .Sum(pc => pc.Part.Price)))
                .ForMember(dst => dst.DiscountPrice,
                    opt => opt.MapFrom(src => src.Car.PartsCars
                        .Sum(pc => pc.Part.Price) * (100 - src.Discount) / 100));


        }
    }
}
