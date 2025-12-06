using Domain.Interfaces;
using OnionLibrary.Application.DTOInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.Application.ManagerInterfaces
{
    public interface IManager<T,U> where T:class,IDto where U: class,IEntity
    {
        //business logic for queries
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        


        //business logic for commands

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<string> DeleteAsync(int id);
    }
}
