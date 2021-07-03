
public class DiretorOutputGetByIdDto
{
    public long Id { get; set; }

    public string Nome { get; set; }
    public DiretorOutputGetByIdDto(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }

}