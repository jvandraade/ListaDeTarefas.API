using System.Collections.Generic;
using System.Threading.Tasks;
using TarefasAPI.Models;

namespace TarefasAPI.Repositories
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<IEnumerable<Tarefa>> GetPendingAsync();
        Task<IEnumerable<Tarefa>> GetCompletedAsync();
        Task<Tarefa> GetByIdAsync(int id);
        Task AddAsync(Tarefa tarefa);
        Task RemoveAsync(int id);
        Task UpdateAsync(Tarefa tarefa);
    }
}
