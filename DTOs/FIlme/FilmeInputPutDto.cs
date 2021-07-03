
public class FilmeInputPutDto
{
     public long Id { get; set; }
    public string Titulo { get; set; }
    public long DiretorId { get; set; }
    public FilmeInputPutDto(long id, string titulo, long diretorId) {
        Id = id;
        Titulo = titulo;
        DiretorId = diretorId;
    }
}
