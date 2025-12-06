using AutoMapper;
using Domain.Entities;
using OnionLibrary.Application.DTOClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.Application.MappingProfile
{
    public class DtoMappingProfile:Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<BookDto,Book>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<TagDto, Tag>().ReverseMap();
            CreateMap<BookTagDto, BookTag>().ReverseMap();
        }

    }
}
