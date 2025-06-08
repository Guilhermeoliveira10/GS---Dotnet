using System;
using System.ComponentModel.DataAnnotations;

namespace SafeZone.Domain.Entities;

public class Alert
{
    public int Id { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Tipo { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Data { get; set; } = DateTime.Now;
}
