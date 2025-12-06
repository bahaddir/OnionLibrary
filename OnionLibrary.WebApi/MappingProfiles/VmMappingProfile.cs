using AutoMapper;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.WebApi.RequestModels.AuthorRequestModels;
using OnionLibrary.WebApi.RequestModels.BookRequestModels;
using OnionLibrary.WebApi.RequestModels.BookTagRequestModels;
using OnionLibrary.WebApi.RequestModels.CategoryRequestModels;
using OnionLibrary.WebApi.RequestModels.TagRequestModels;
using OnionLibrary.WebApi.ResponseModels.AuthorResponseModel;
using OnionLibrary.WebApi.ResponseModels.BookResponseModel;
using OnionLibrary.WebApi.ResponseModels.BookTagResponseModel;
using OnionLibrary.WebApi.ResponseModels.CategoryResponseModel;
using OnionLibrary.WebApi.ResponseModels.TagResponseModel;

namespace OnionLibrary.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateAuthorRequestModel, AuthorDto>();
            CreateMap<UpdateAuthorRequestModel, AuthorDto>();
            CreateMap<AuthorDto, AuthorResponseModel>();

            CreateMap<CreateBookRequestModel, BookDto>();
            CreateMap<UpdateBookRequestModel, BookDto>(); 
            CreateMap<BookDto, BookResponseModel>();

            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();

            CreateMap<CreateTagRequestModel, TagDto>();
            CreateMap<UpdateTagRequestModel, TagDto>();
            CreateMap<TagDto, TagResponseModel>();

            CreateMap<CreateBookTagRequestModel, BookTagDto>();
            CreateMap<UpdateBookTagRequestModel, BookTagDto>();
            CreateMap<BookTagDto, BookTagResponseModel>();



        }
    }
}
