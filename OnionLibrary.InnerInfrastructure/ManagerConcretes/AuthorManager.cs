using AutoMapper;
using Domain.Entities;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.Contract.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.InnerInfrastructure.ManagerConcretes
{
    

    public class AuthorManager(IAuthorRepository repository, IMapper mapper, IServiceProvider serviceProvider) : BaseManager<AuthorDto, Author>(repository, mapper, serviceProvider), IAuthorManager
    {
        private readonly IAuthorRepository _repository = repository;
    }

    
}
