using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



namespace WebApi.FilmeController
{


    [ApiController]
    [Route("api/v1/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmeController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Filme>> Post([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            try
            {
                if (filme == null)
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
        [HttpGet]
        public async Task<List<Filme>> Get()
        {

            return await _context.Filmes.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> Get(long id)
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);

            return Ok(filme);
        }

        [HttpPut]
        public async Task<ActionResult<Filme>> Get(long id, [FromBody] Filme filme)
        {
            filme.Id = id;
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
            return Ok(filme);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Filme>> Delete(long id)
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);
            filme.Id = id;
            _context.Remove(filme);
            await _context.SaveChangesAsync();
            return Ok(filme);
        }

    }
}