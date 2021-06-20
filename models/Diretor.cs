using System.Collections.Generic;
public class Diretor
{

    public long Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Filme> Filmes { get; set; }

    public Diretor()
    {

        Filmes = new List<Filme>();

    }
}