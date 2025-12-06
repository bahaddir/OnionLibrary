using AutoMapper;
using FluentValidation; 
using Microsoft.Extensions.DependencyInjection; 
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
    public abstract class BaseManager<T, U> : IManager<T, U> where T : class, IDto where U : class, IEntity
    {
        protected readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;
        private readonly IValidator<T>? _validator;

        // constructora iserviceprovider ekledim ki validator'ü alabilelim
        protected BaseManager(IRepository<U> repository, IMapper mapper, IServiceProvider serviceProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = serviceProvider.GetService<IValidator<T>>();
        }

        public async Task CreateAsync(T entity)
        {
            if (_validator != null)
            {
                var validationResult = await _validator.ValidateAsync(entity);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                    throw new Exception($"dogrulama hatasi: {errors}");
                }
            }

            try
            {
                U domainEntity = _mapper.Map<U>(entity);
                domainEntity.CreatedDate = DateTime.Now;
                await _repository.CreateAsync(domainEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"hata: {ex.Message}", ex);
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                U value = await _repository.GetByIdAsync(id);
                if (value == null) return "silinecek veri bulunamadi.";
                await _repository.DeleteAsync(value);
                return $"{id} id'li veri silindi";
            }
            catch (Exception ex)
            {
                throw new Exception($"silme hatasi: {ex.Message}", ex);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                List<U> values = await _repository.GetAllAsync();
                return _mapper.Map<List<T>>(values);
            }
            catch (Exception ex)
            {
                throw new Exception($"hata : {ex.Message}", ex);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                U value = await _repository.GetByIdAsync(id);
                return _mapper.Map<T>(value);
            }
            catch (Exception ex)
            {
                throw new Exception($"hata : {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (_validator != null)
            {
                var validationResult = await _validator.ValidateAsync(entity);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                    throw new Exception($"hata : {errors}");
                }
            }

            try
            {
                U originalValue = await _repository.GetByIdAsync(entity.Id);

                if (originalValue == null) throw new Exception("veri bulunamadi.");
                U newValue = _mapper.Map<U>(entity);
                newValue.CreatedDate = originalValue.CreatedDate; 
                newValue.UpdatedDate = DateTime.Now;

                await _repository.UpdateAsync(originalValue, newValue);
            }
            catch (Exception ex)
            {
                throw new Exception($"hata: {ex.Message}", ex);
            }
        }
    }
}