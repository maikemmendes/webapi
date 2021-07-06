using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



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
    public async Task<ActionResult<FilmeOutputPostDto>> Post([FromBody] FilmeInputPostDto inputDTO)
    {

        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == inputDTO.DiretorId);

        if (diretor == null)
        {
            return NotFound("Diretor não foi encontrado");
        }

        var filme = new Filme(inputDTO.Titulo, diretor.Id);
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        var outputDTO = new FilmeOutputPostDto(filme.Id, filme.Titulo);

        return Ok(outputDTO);
    }
    [HttpGet]
    public async Task<List<FilmeOutputGetAllDto>> Get()
    {

        var filmes = await _context.Filmes.ToListAsync();

        if (!filmes.Any())
        {
            return NotFound("Não existem diretores cadastrados!");
        }

        var outputDTOList = new List<FilmeOutputGetAllDto>();

        foreach (Filme filme in filmes)
        {
            outputDTOList.Add(new FilmeOutputGetAllDto(filme.Id, filme.Titulo));
        }

        return outputDTOList;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FilmeOutputGetByIdDto>> Get(long id)
    {
        var filme = await _context.Filmes.Include(filme => filme.Diretor).FirstOrDefaultAsync(filme => filme.Id == id);
        if (filme == null)
        {
            throw new ArgumentNullException("Filme não encontrado!");
        }
        var outputDTO = new FilmeOutputGetByIdDto(filme.Id, filme.Titulo, filme.Diretor.Nome);
        return Ok(outputDTO);


    }

    [HttpPut]
    public async Task<ActionResult<FilmeOutPutDTO>> Put(long id, [FromBody] FilmeInputPutDto inputDTO)
    {
        var filme = new Filme(inputDTO.Titulo, inputDTO.DiretorId);
        if (inputDTO.DiretorId == 0)
        {
            return NotFound("Id do diretor é inválido!");
        }
        filme.Id = id;
        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();

        var outputDTO = new FilmeOutPutDTO(filme.Id, filme.Titulo);
        return Ok(outputDTO);
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
