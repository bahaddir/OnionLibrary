using AutoMapper;
using Domain.Entities;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.Contract.RepositoryInterfaces;

namespace OnionLibrary.InnerInfrastructure.ManagerConcretes
{
    public class TagManager(ITagRepository repository, IMapper mapper) : BaseManager<TagDto, Tag>(repository, mapper), ITagManager
    {
        private readonly ITagRepository _repository = repository;
    }
}
