using Domain.Entities;
using OnionLibrary.Contract.RepositoryInterfaces;
using OnionLibrary.Persistence.ContextClasses;

namespace OnionLibrary.Persistence.RepositoryConcretes
{
    public class TagRepository(MyContext context) : BaseRepository<Tag>(context), ITagRepository
    {

    }
}

