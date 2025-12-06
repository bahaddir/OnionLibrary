using AutoMapper;
using Domain.Entities;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.Contract.RepositoryInterfaces;

namespace OnionLibrary.InnerInfrastructure.ManagerConcretes
{
    public class CategoryManager(ICategoryRepository repository, IMapper mapper, IServiceProvider serviceProvider) : BaseManager<CategoryDto, Category>(repository, mapper,serviceProvider), ICategoryManager
    {
        private readonly ICategoryRepository _repository = repository;
    }
}
