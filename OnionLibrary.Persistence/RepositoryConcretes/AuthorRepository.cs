using Domain.Entities;
using OnionLibrary.Contract.RepositoryInterfaces;
using OnionLibrary.Persistence.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.Persistence.RepositoryConcretes
{
    public class AuthorRepository(MyContext context) : BaseRepository<Author>(context), IAuthorRepository
    {

    }
}

