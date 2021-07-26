
using FluentValidation;

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

    
public class FilmeInputPutDtoValidation : AbstractValidator<FilmeInputPutDto>
{
    
    public FilmeInputPutDtoValidation()
    {
        RuleFor (filme => filme.Titulo).NotNull().NotEmpty();
        RuleFor (filme => filme.DiretorId).NotNull().NotEmpty();
    }
}
}
