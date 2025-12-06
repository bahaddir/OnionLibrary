using AutoMapper;
using Domain.Entities;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.Contract.RepositoryInterfaces;
using System;

namespace OnionLibrary.InnerInfrastructure.ManagerConcretes
{
    public class BookManager(IBookRepository repository, IMapper mapper,IServiceProvider serviceProvider) : BaseManager<BookDto, Book>(repository, mapper, serviceProvider), IBookManager
    {
        private readonly IBookRepository _repository = repository;
    }
}
