
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")] //movie

public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> Get()
        {
            try
            {
                var movies = await _context.Filmes.ToListAsync();

                if (!filmes.Any())
                {
                    return NotFound("Movies not found.");
                }

                return Ok(filmes);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> Get(int id)
        {
            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);

                if (filme == null)
                {
                    return NotFound("Movie not found.");
                }

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // POST api/movies
        [HttpPost]
        public async Task<ActionResult<Filme>> Post([FromBody] Filme filme)
        {
            try
            {
                var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == filme.DiretorId);

                if (diretor == null) {
                    return NotFound("Director not found.");
                }

                _context.Filmes.Add(filme);
                await _context.SaveChangesAsync();

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Filme>> Put(int id, [FromBody] Filme filme)
        {
            try
            {
                filme.Id = id;
                _context.Filmes.Update(filme);
                await _context.SaveChangesAsync();

                return Ok(filme);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var movie = _context.Filmes.FirstOrDefault(movie => movie.Id == id);
                _context.Remove(filme);
                _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
