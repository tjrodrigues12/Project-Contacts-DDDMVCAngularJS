using System;
using System.Collections.Generic;
using System.Text;

using FluentValidation;
using Project.Domain.Interfaces;
using Project.Domain.Entities;
using Project.Infra.Data.Repository;
using System.Linq.Dynamic;

namespace Project.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        protected BaseRepository<T> repository = new BaseRepository<T>();

        /// <summary>
        /// Get Data with id
        /// </summary>mj[´ª    
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return repository.Select(id);
        }

        /// <summary>
        /// Get data List
        /// </summary>
        /// <returns></returns>
        public IList<T> Get() => repository.Select();
        
        /// <summary>
        /// Include data in database
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        /// <summary>
        /// Change data in database
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        /// <summary>
        /// Remove data in Database
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Delete(id);

        }

        /// <summary>
        /// Function to validate object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="validator"></param>
        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("The Records not found!");

            validator.ValidateAndThrow(obj);
        }
    }
}
