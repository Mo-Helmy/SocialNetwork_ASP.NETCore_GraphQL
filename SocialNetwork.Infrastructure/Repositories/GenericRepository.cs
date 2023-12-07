using Microsoft.EntityFrameworkCore;
using SocialNetwork.Infrastructure.Data;
using SocialNetwork.Infrastructure.Repositories.Contract;
using SocialNetwork.Infrastructure.Specifications;
using SocialNetwork.Infrastructure.Specifications.Contract;
using System.Reflection;

namespace SocialNetwork.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Query Methods
        public IQueryable<T> GetAllAsync()
        {
            using (var dbContext = _dbContext)
            {
                IQueryable<T> query = _dbContext.Set<T>();

                return query;
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> GetCountWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T?> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
        #endregion

        #region Command Methods
        public async Task<T?> CreateAsync(T entity)
        {
            //throw new NotImplementedException();
            //entity.DateCreated = DateTime.Now;
            //entity.IsDeleted = false;

            await _dbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            //throw new NotImplementedException();

            //var entity = await _dbContext.Set<T>().FindAsync(id);

            //if (entity is null) return null;

            //entity.IsDeleted = true;
            //entity.DateDeleted = DateTime.Now;

            _dbContext.Set<T>().Remove(entity);

            //return entity;
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            //throw new NotImplementedException();

            //var currentEntity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);

            //if (currentEntity is null) return null;

            //entity.DateCreated = currentEntity.DateCreated;

            //UpdateObject(currentEntity, entity);

            //currentEntity.DateUpdated = DateTime.Now;

            ////_dbContext.Entry(entity).State = EntityState.Modified;

            _dbContext.Set<T>().Update(entity);

            return entity;
        }

        private static void UpdateObject(object target, object source)
        {
            Type targetType = target.GetType();
            Type sourceType = source.GetType();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo targetProperty = targetType.GetProperty(sourceProperty.Name);
                if (targetProperty != null && targetProperty.PropertyType == sourceProperty.PropertyType)
                {
                    object value = sourceProperty.GetValue(source, null);
                    targetProperty.SetValue(target, value, null);
                }
            }
        }

        #endregion


    }
}
