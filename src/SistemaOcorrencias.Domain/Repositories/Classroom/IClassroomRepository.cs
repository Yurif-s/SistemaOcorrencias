namespace SistemaOcorrencias.Domain.Repositories.Classroom;

public interface IClassroomRepository
{
    public Task AddAsync(Entities.Classroom classroom);
    public Task<List<Entities.Classroom>> GetAllAsync();
    public Task<Entities.Classroom?> GetByIdAsync(int id);
    public Task<bool> DeleteAsync(int id);
}
