
public class FilmeInputPostDto
{
    public long Id { get; set; }
    public string Titulo{ get; set; }
    public int Ano { get; set; }
    public string Genero { get; set; }
    public long DiretorId { get; set; }
    public Diretor Diretor { get; set; }
}