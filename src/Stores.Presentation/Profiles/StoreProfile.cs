using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Models;

namespace Stores.Presentation.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDto>()
                .ReverseMap();
            CreateMap<Store, StoreRequest>()
                .ReverseMap();

            CreateMap<StoreDto, StoreRequest>()
                .ReverseMap();

            CreateMap<Item, ItemDto>()
                .ReverseMap();

            CreateMap<ItemDto, ItemRequest>()
                .ReverseMap();

            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<CategoryDto, CategoryRequest>()
                .ReverseMap();
            CreateMap<Category, CategoryRequest>()
                .ReverseMap();

            CreateMap<CategoryType, CategoryTypeDto>()
                .ReverseMap();
            CreateMap<CategoryType, CategoryTypeRequest>()
                .ReverseMap();

            CreateMap<CategoryTypeDto, CategoryTypeRequest>()
                .ReverseMap();
        }
    }
}
