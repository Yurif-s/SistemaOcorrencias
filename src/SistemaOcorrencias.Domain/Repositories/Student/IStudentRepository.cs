namespace SistemaOcorrencias.Domain.Repositories.Student;

public interface IStudentRepository
{
    public Task AddAsync(Domain.Entities.Student student);
    public Task<bool> DeleteAsync(int id);
    public Task<Domain.Entities.Student?> GetByIdAsync(int id);
    public Task<List<Domain.Entities.Student>> GetAllAsync();
    public Task UpdateAsync(int id, Domain.Entities.Student user);
}
