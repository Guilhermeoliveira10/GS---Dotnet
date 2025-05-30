using System;

namespace SafeZone.Domain.Entities;

public class Alert
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public DateTime Data { get; set; } = DateTime.Now;
}
