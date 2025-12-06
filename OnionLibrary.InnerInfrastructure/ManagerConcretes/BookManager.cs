using AutoMapper;
using Domain.Entities;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.Contract.RepositoryInterfaces;

namespace OnionLibrary.InnerInfrastructure.ManagerConcretes
{
    public class BookManager(IBookRepository repository, IMapper mapper) : BaseManager<BookDto, Book>(repository, mapper), IBookManager
    {
        private readonly IBookRepository _repository = repository;
    }
}
