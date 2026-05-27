using SistemaOcorrencias.Domain.Entities;

namespace SistemaOcorrencias.Domain.Repositories.User;

public interface IUserRepository
{
    public Task AddAsync(Domain.Entities.User user);
    public Task<bool> DeleteAsync(int id);
    public Task<Domain.Entities.User?> GetByIdAsync(int id);
    public Task UpdateAsync(int id, Domain.Entities.User user);
}
