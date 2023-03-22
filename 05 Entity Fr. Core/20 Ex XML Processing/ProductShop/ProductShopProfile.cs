using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportDTO01User, User>()
                .ForMember(dst => dst.Age,
                    opt => opt.MapFrom(src => src.Age!.Value));
            this.CreateMap<ImportDTO02Product, Product>()
                .ForMember(dst => dst.BuyerId,
                    opt => opt.MapFrom(src => src.BuyerId!.Value));
            this.CreateMap<ImportDTO03Category, Category>();
            this.CreateMap<ImportDTO04CategoryProduct, CategoryProduct>();

            this.CreateMap<Product, ExportDTO05ProductsInRange>()
                .ForMember(dst => dst.Buyer,
                    //opt => opt.MapFrom(src => src.Buyer != null ?
                    //    String.Format("{0} {1}", src.Buyer.FirstName, src.Buyer.LastName)
                    //    : null ));
                    opt => opt.MapFrom(src => String.Format("{0} {1}", src.Buyer!.FirstName, src.Buyer.LastName)));
            this.CreateMap<Product, ExportDTO06ProductForUser>();
            this.CreateMap<User, ExportDTO06UserWithProducts>();
            this.CreateMap<Category, ExportDTO07CategoryByProduct>()
                .ForMember(dst => dst.Count,
                    opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dst => dst.AveragePrice,
                    opt => opt.MapFrom(src => src.CategoryProducts
                        .Average(cp => cp.Product.Price)))
                .ForMember(dst => dst.TotalRevenue,
                    opt => opt.MapFrom(src => src.CategoryProducts
                        .Sum(cp => cp.Product.Price)));
            this.CreateMap<Product, ExportDTO08ProductSoldForUser>();
            this.CreateMap<User, ExportDTO08ProdictsForUser>()
                .ForMember(dst => dst.Count,
                    opt => opt.MapFrom(src => src.ProductsSold.Count));
            this.CreateMap<User, ExportDTO08UserWithSoldProducts>()
                .ForMember(dst => dst.Age,
                    opt => opt.MapFrom(src => src.Age!.Value))
                .ForMember(dst => dst.PRODUCTS,
                    opt => opt.MapFrom(src => src));

        }
    }
}
