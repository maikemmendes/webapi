public class Diretor {

    public int Id {get; set;}
    public string Nome {get; set;}
     public ICollection<FIlme> FIlme {get; set; }

public Diretor()
    {
        Filme = new List<Filme>();
    }
}