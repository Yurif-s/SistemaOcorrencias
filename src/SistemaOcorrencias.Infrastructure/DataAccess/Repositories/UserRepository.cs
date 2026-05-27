using Microsoft.EntityFrameworkCore;
using SistemaOcorrencias.Domain.Entities;
using SistemaOcorrencias.Domain.Repositories.User;

namespace SistemaOcorrencias.Infrastructure.DataAccess.Repositories;

internal class UserRepository(AppDbContext appDbContext) : IUserRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task AddAsync(User user) => await _appDbContext.Users.AddAsync(user);

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _appDbContext.Users.FindAsync(id);

        if (user is null)
            return false;

        _appDbContext.Users.Remove(user);
        return true;
    }

    public async Task<User?> GetByIdAsync(int id) => await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

    public async Task UpdateAsync(int id, Domain.Entities.User user)
    {
        var entity = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (entity is null) return;

        entity.Name = user.Name;
        entity.Email = user.Email;
    }
}
