using SocialNetwork.Infrastructure.Specifications.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Repositories.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(string id);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        Task<T?> GetByIdWithSpecAsync(ISpecification<T> spec);
        Task<int> GetCountWithSpecAsync(ISpecification<T> spec);



        Task<T?> CreateAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
