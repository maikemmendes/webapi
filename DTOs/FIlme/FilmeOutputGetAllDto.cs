
public class FilmeOutputGetAllDto
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public FilmeOutputGetAllDto(long id, string titulo)
    {
        Id = id;
        Titulo = titulo;
      }
}