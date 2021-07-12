using FluentValidation;

public class DiretorInputPutDTO
    {
        public string Nome { get; set;}
    }

    public class DiretorInputPutDTOValidation : AbstractValidator<DiretorInputPutDTO>
    {
      public DiretorInputPutDTOValidation(){

          RuleFor(diretor => diretor.Nome).NotNull().NotEmpty();
          

      }
    }
