using Domain.Entities;
using OnionLibrary.Contract.RepositoryInterfaces;
using OnionLibrary.Persistence.ContextClasses;

namespace OnionLibrary.Persistence.RepositoryConcretes
{
    public class BookRepository(MyContext context) : BaseRepository<Book>(context), IBookRepository
    {

    }
}

