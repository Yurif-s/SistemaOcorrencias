using Microsoft.EntityFrameworkCore;
using SistemaOcorrencias.Domain.Entities;
using SistemaOcorrencias.Domain.Repositories.Classroom;

namespace SistemaOcorrencias.Infrastructure.DataAccess.Repositories;

internal class ClassroomRepository(AppDbContext appDbContext) : IClassroomRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task AddAsync(Domain.Entities.Classroom classroom) => await _appDbContext.Classrooms.AddAsync(classroom);

    public async Task<bool> DeleteAsync(int id)
    {
        var classroom = await _appDbContext.Classrooms.FindAsync(id);

        if (classroom is null)
            return false;

        _appDbContext.Classrooms.Remove(classroom);
        return true;
    }

    public async Task<List<Domain.Entities.Classroom>> GetAllAsync() => await _appDbContext.Classrooms.AsNoTracking().ToListAsync();

    public async Task<Classroom?> GetByIdAsync(int id) => await _appDbContext.Classrooms.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
}
