using Microsoft.EntityFrameworkCore;
public class  ApplicatioDbContext : DbContext 
{
    public DbSet<Filme> Filmes {get; set;}
    
    public DbSet<Diretor> Diretor {get; set;}
}