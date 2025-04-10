namespace RedSocial.Models;

public class Profile
{
    public string Nickname { get; set; }
    public int GeneroId { get; set; }
    public CatGenero Genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
}