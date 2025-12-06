using AutoMapper;
using Domain.Entities;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.Contract.RepositoryInterfaces;

namespace OnionLibrary.InnerInfrastructure.ManagerConcretes
{
    public class BookTagManager(IBookTagRepository repository, IMapper mapper, IServiceProvider serviceProvider) : BaseManager<BookTagDto, BookTag>(repository, mapper,serviceProvider), IBookTagManager
    {
        private readonly IBookTagRepository _repository = repository;
    }
}
