namespace SafeZone.Domain.Entities;

public class RiskZone
{
	public int Id { get; set; }
	public string Local { get; set; } = string.Empty;
	public string NivelRisco { get; set; } = string.Empty;
	public double Latitude { get; set; }
	public double Longitude { get; set; }
}
