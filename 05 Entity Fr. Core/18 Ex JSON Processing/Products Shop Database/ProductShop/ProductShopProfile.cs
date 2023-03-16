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
            this.CreateMap<ImportDTOUser, User>();
            this.CreateMap<ImportDTOProduct, Product>();
            this.CreateMap<ImportDTOCategory, Category>();
            this.CreateMap<Product, ExportDTOProductInRange>()
                .ForMember(d => d.ProductName,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice,
                    opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.SellerName,
                    //opt => opt.MapFrom(s => String.Format("{0} {1}", s.Seller.FirstName, s.Seller.LastName)));
                    opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

        }
    }
}
