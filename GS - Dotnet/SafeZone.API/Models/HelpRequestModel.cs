namespace SafeZone.API.Models;

public class HelpRequestModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string TipoAjuda { get; set; } = string.Empty;       // ✅ Adicione isso
    public string Localizacao { get; set; } = string.Empty;     // ✅ Adicione isso
    public DateTime DataSolicitacao { get; set; }               // ✅ Adicione isso

    public List<LinkModel> Links { get; set; } = new();
}

public class LinkModel
{
    public string Href { get; set; } = string.Empty;
    public string Rel { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
}
