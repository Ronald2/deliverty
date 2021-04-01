using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specs;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
         Task<T> GetByIdAsync(int id);
         Task<IReadOnlyList<T>> AllListAsync();

         Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);
         Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec);


    }
}