using Domain.Entities;
using OnionLibrary.Contract.RepositoryInterfaces;
using OnionLibrary.Persistence.ContextClasses;

namespace OnionLibrary.Persistence.RepositoryConcretes
{
    public class BookTagRepository(MyContext context) : BaseRepository<BookTag>(context), IBookTagRepository
    {

    }
}

