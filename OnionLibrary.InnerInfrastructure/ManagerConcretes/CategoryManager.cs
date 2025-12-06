using AutoMapper;
using Domain.Entities;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.Contract.RepositoryInterfaces;

namespace OnionLibrary.InnerInfrastructure.ManagerConcretes
{
    public class CategoryManager(ICategoryRepository repository, IMapper mapper) : BaseManager<CategoryDto, Category>(repository, mapper), ICategoryManager
    {
        private readonly ICategoryRepository _repository = repository;
    }
}
