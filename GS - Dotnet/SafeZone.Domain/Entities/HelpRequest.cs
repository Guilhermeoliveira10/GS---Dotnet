public class HelpRequest
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string TipoAjuda { get; set; } = string.Empty;
    public string Localizacao { get; set; } = string.Empty;
    public DateTime DataSolicitacao { get; set; } = DateTime.Now;
}
