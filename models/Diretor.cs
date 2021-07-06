using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Diretor : IValidatableObject
{

    public long Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Filme> Filmes { get; set; }

    public Diretor(string nome)
    {

        Nome = nome;
        Filmes = new List<Filme>();

    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
          throw new System.NotImplementedException();
    }
}