using AutoMapper;
using Webjar.Application.DTOs.Accessory;
using Webjar.Application.DTOs.ColorVariable;
using Webjar.Application.DTOs.Product;
using Webjar.Application.DTOs.SizeVariable;
using Webjar.Domain;

namespace Webjar.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
			#region Accessory Mapping
			CreateMap<Accessory, AccessoryDto>().ReverseMap();
			#endregion

			#region ColorVariable Mapping
			CreateMap<ColorVariable, ColorVariableDto>().ReverseMap();
			#endregion

			#region SizeVariable Mapping
			CreateMap<SizeVariable, SizeVariableDto>().ReverseMap();
			#endregion

			#region Products Mapping
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, ProductDto>().ReverseMap();
			#endregion

		}
	}
}
