using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;
using Task = System.Threading.Tasks.Task;

namespace SocialNetwork.Application.Services.Contract
{
    public interface IGenericService<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task<T?> CreateAsync(T entity);

        Task<T?> UpdateAsync(int id, object updateCommand);
        Task<T?> UpdateAsync(string id, object updateCommand);

        Task DeleteAsync(int id);

    }
}
