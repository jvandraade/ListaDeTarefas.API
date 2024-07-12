using TarefasAPI.Exceptions;
using TarefasAPI.Models;
using TarefasAPI.Repositories;

namespace TarefasAPI.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Tarefa>> GetPendingAsync()
        {
            return await _repository.GetPendingAsync();
        }

        public async Task<IEnumerable<Tarefa>> GetCompletedAsync()
        {
            return await _repository.GetCompletedAsync();
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            var existingTarefa = await _repository.GetByIdAsync(tarefa.Id);
            if (existingTarefa != null)
            {
                throw new TarefaException("Já existe uma tarefa com esse ID.");
            }

            await _repository.AddAsync(tarefa);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task MarkAsCompletedAsync(int id)
        {
            var tarefa = await _repository.GetByIdAsync(id);
            if (tarefa != null)
            {
                tarefa.Status = true;
                await _repository.UpdateAsync(tarefa);
            }
        }
    }
}
