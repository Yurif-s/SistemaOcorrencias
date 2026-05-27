using SistemaOcorrencias.Domain.Enums;

namespace SistemaOcorrencias.Domain.Entities;

public class Occurrence
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateOnly OccurrenceDate { get; set; }
    public Gravity GravityType { get; set; }

    public int StudentId { get; set; }
    public int ClassroomId { get; set; }
    public int RegisteredById { get; set; }

    public Student Student { get; set; } = null!;
    public Classroom Classroom { get; set; } = null!;
    public User RegisteredBy { get; set; } = null!;
}

