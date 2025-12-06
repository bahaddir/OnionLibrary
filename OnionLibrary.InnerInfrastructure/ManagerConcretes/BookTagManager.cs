using AutoMapper;
using Domain.Entities;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.Contract.RepositoryInterfaces;

namespace OnionLibrary.InnerInfrastructure.ManagerConcretes
{
    public class BookTagManager(IBookTagRepository repository, IMapper mapper) : BaseManager<BookTagDto, BookTag>(repository, mapper), IBookTagManager
    {
        private readonly IBookTagRepository _repository = repository;
    }
}
