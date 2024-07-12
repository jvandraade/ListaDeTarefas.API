using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TarefasAPI.Data;
using TarefasAPI.Models;

namespace TarefasAPI.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefasContext _context;

        public TarefaRepository(TarefasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> GetPendingAsync()
        {
            return await _context.Tarefas.Where(t => !t.Status).ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> GetCompletedAsync()
        {
            return await _context.Tarefas.Where(t => t.Status).ToListAsync();
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
