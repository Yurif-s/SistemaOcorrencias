using Microsoft.EntityFrameworkCore;
using SistemaOcorrencias.Domain.Entities;
using SistemaOcorrencias.Domain.Repositories.Student;

namespace SistemaOcorrencias.Infrastructure.DataAccess.Repositories;

internal class StudentRepository(AppDbContext appDbContext) : IStudentRepository
{ 
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task AddAsync(Student student) => await _appDbContext.Students.AddAsync(student);

    public async Task<bool> DeleteAsync(int id)
    {
        var student = await _appDbContext.Students.FindAsync(id);

        if (student is null)
            return false;

        _appDbContext.Students.Remove(student);
        return true;
    }

    public async Task<List<Student>> GetAllAsync() => await _appDbContext.Students.AsNoTracking().ToListAsync();

    public async Task<Student?> GetByIdAsync(int id) => await _appDbContext.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

    public async Task UpdateAsync(int id, Student student)
    {
        var entity = await _appDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);

        if (entity is null) return;

        entity.Name = student.Name;
    }
}
