
using FluentValidation;

public class FilmeInputPostDto
{
    public long Id { get; set; }
    public string Titulo{ get; set; }
    public int Ano { get; set; }
    public string Genero { get; set; }
    public long DiretorId { get; set; }
    public Diretor Diretor { get; set; }
}

public class FilmeInputPostDtoValidation : AbstractValidator<FilmeInputPostDto>
{
    
    public FilmeInputPostDtoValidation()
    {
        RuleFor (filme => filme.Titulo).NotNull().NotEmpty();
        RuleFor (filme => filme.Ano).NotNull().NotEmpty();
        RuleFor (filme => filme.DiretorId).NotNull().NotEmpty();
    }
}