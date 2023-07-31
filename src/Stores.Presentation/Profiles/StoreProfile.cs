using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Models;
using Stores.DataAccess.Helpers;

namespace Stores.Presentation.Profiles;

/// <summary>
/// The mapping of all the profile of the store
/// </summary>
public class StoreProfile : Profile
{

    /// <summary>
    /// Initializes a new instance of <see cref="StoreProfile"/>
    /// </summary>
    public StoreProfile()
    {
        CreateMap<Store, StoreDto>()
            .ReverseMap();
        CreateMap<Store, StoreRequest>()
            .ReverseMap();
        CreateMap<StoreDto, StoreRequest>()
            .ReverseMap();
        CreateMap<PageResult<Store>, PageResult<StoreDto>>()
            .ReverseMap();

        CreateMap<Item, ItemDto>()
            .ReverseMap();
        CreateMap<ItemDto, ItemRequest>()
            .ReverseMap();
        CreateMap<Item, ItemRequest>()
            .ReverseMap();
        CreateMap<PageResult<Item>, PageResult<ItemDto>>()
           .ReverseMap();

        CreateMap<Category, CategoryDto>()
            .ReverseMap();
        CreateMap<CategoryDto, CategoryRequest>()
            .ReverseMap();
        CreateMap<Category, CategoryRequest>()
            .ReverseMap();
        CreateMap<PageResult<Category>, PageResult<CategoryDto>>()
           .ReverseMap();


        CreateMap<CategoryType, CategoryTypeDto>()
            .ReverseMap();
        CreateMap<CategoryType, CategoryTypeRequest>()
            .ReverseMap();
        CreateMap<CategoryTypeDto, CategoryTypeRequest>()
            .ReverseMap();
        CreateMap<PageResult<CategoryType>, PageResult<CategoryTypeDto>>()
           .ReverseMap();
    }
}
