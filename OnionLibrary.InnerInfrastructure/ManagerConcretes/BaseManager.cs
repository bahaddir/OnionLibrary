using AutoMapper;
using Domain.Interfaces;
using OnionLibrary.Application.DTOInterfaces;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.Contract.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.InnerInfrastructure.ManagerConcretes
{
    public abstract class BaseManager<T,U> : IManager<T,U> where T:class,IDto where U:class,IEntity
    {
        private readonly IRepository<U> _repository;
        private readonly IMapper _mapper;

        protected BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(T entity)
        {

            U domainEntity = _mapper.Map<U>(entity);
            domainEntity.CreatedDate = DateTime.Now;

            await _repository.CreateAsync(domainEntity);
        }

        public async Task<string> DeleteAsync(int id)
        {
            U value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
            return $"{id} id'li veri silindi";
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<U> values = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            U value = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(value);
        }

        public async Task UpdateAsync(T entity)
        {
            U originalValue = await _repository.GetByIdAsync(entity.Id);
            U newValue = _mapper.Map<U>(entity);
            newValue.UpdatedDate = DateTime.Now;
            await _repository.UpdateAsync(originalValue, newValue);
        }
    }
}
