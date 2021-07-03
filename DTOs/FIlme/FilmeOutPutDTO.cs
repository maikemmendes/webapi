
public class FilmeOutPutDTO
{
     public long Id { get; set; }
    public string Titulo { get; set; }
    public FilmeOutPutDTO(long id, string titulo) {
        Id = id;
        Titulo = titulo;
    }
}
