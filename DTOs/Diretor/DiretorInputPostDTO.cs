
using FluentValidation;

public class DiretorInputPostDTO
{
    public string Nome { get; set;}

}

public class DiretorInputPostDTOValidator : AbstractValidator<DiretorInputPostDTO>{

    public DiretorInputPostDTOValidator(){
        RuleFor(diretor => diretor.Nome).NotNull().NotEmpty();
        RuleFor(diretor => diretor.Nome).Length(2, 150).WithMessage("Tamanho de {TotalLength} é inválido");
        
    }
}
    
