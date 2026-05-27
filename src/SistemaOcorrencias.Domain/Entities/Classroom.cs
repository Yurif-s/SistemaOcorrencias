namespace SistemaOcorrencias.Domain.Entities;

public class Classroom
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Course { get; set; } = string.Empty;
    public ICollection<Student> Students { get; set; } = [];
    public ICollection<Occurrence> Occurrences { get; set; } = [];
}
