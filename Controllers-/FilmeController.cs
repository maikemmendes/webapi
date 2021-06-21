using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.FilmeController
{


    [ApiController]
    [Route("controller")]
    public class FilmeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmeController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost("{id}")]
        public async Task<ActionResult<Filme>> Post([FromBody] Filme filme)
        {

            _context.Filmes.Add(filme);

            var diretor = await _context.Diretores.FirstOrDefaultAsync(director => director.Id == filme.DiretorId);
            try
            {
                if (diretor == null)
                {
                    return NotFound("Não foi encontrado o diretor com esse id");
                }
                await _context.SaveChangesAsync();

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }


        }


    }
}