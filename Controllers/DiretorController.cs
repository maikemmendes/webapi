using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("controller")]
public class DiretorController : ControllerBase
{

    private readonly ApplicationDbContext _context;

    public DiretorController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]//Get ALL
    public async Task<ActionResult<List<DiretorOutputGetAllDto>>> Get()
    {

        try
        {
            var diretores = await _context.Diretores.ToListAsync();

            if (!diretores.Any())
            {

                return NotFound("Não existem diretores cadastrados");

            }

            var outputDTOList = new List<DiretorOutputGetAllDto>();

            foreach (Diretor diretor in diretores)
            {
                outputDTOList.Add(new DiretorOutputGetAllDto(diretor.Id, diretor.Nome));
            }

            return outputDTOList;

        }
        catch (Exception ex)
        {

            return Conflict(ex.Message);
        }


    }


    //Get By id
    [HttpGet("{id}")]
    public async Task<ActionResult<DiretorOutputGetByIdDto>> Get(long id)
    {
        try
        {
            var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);

            if (diretor == null)
            {
                return NotFound("Diretor não encontrado");
            }

            var outputDto = new DiretorOutputGetByIdDto(diretor.Id, diretor.Nome);

            return Ok(diretor);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post([FromBody] DiretorInputPostDTO diretorInputPostDto)
    {
        try
        {
            var diretor = new Diretor(diretorInputPostDto.Nome);
            _context.Diretores.Add(diretor);


            await _context.SaveChangesAsync();
            var diretorOutputPostDTO = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);
            return Ok(diretor);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DiretorOutputPostDTO>> Put(long id, [FromBody] DiretorInputPutDTO diretorInputPutDTO)
    {
        try{
        var diretor = new Diretor(diretorInputPutDTO.Nome);
        diretor.Id = id;
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();

        var diretorOutputDto = new DiretorOutputPutDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
        }catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Diretor>> Delete(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        diretor.Id = id;
        _context.Remove(diretor);
        await _context.SaveChangesAsync();
        return Ok(diretor);

    }



}