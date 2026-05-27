namespace SistemaOcorrencias.Domain.Repositories;

public interface IUnitOfWork
{
    public Task CommitAsync();
}
