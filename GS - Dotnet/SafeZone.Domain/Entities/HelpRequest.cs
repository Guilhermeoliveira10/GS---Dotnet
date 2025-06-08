using System;
using System.ComponentModel.DataAnnotations;

namespace SafeZone.Domain.Entities;

public class HelpRequest
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string TipoAjuda { get; set; } = string.Empty;

    public string Localizacao { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DataSolicitacao { get; set; } = DateTime.Now;
}
