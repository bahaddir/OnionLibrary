using Domain.Entities;
using OnionLibrary.Contract.RepositoryInterfaces;
using OnionLibrary.Persistence.ContextClasses;

namespace OnionLibrary.Persistence.RepositoryConcretes
{
    public class CategoryRepository(MyContext context) : BaseRepository<Category>(context), ICategoryRepository
    {

    }
}

