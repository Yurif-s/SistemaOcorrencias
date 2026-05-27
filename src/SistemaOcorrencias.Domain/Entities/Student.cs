namespace SistemaOcorrencias.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int RegistrationNumber { get; set; }
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; } = null!;
    public ICollection<Occurrence> Occurrences { get; set; } = [];
}
