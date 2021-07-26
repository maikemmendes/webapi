
public class DiretorOutputGetAllDto
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public DiretorOutputGetAllDto(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }

}
