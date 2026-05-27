using SistemaOcorrencias.Domain.Repositories;

namespace SistemaOcorrencias.Infrastructure.DataAccess.Repositories;

internal class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly AppDbContext _appDbContext = appDbContext;
    public async Task CommitAsync() => await _appDbContext.SaveChangesAsync();
}
