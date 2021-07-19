using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class DiretorService : IDiretorService {
    private readonly ApplicationDbContext _context;
    public DiretorService(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<List<Diretor>> GetAll() {
        var diretores = await _context.Diretores.ToListAsync();

        if (!diretores.Any()) {
            throw new System.Exception("Não existem diretores cadastrados!");
        }

        return diretores;
    }
}