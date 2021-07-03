using System.Collections.Generic;
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

    //Get ALL
     public async Task<List<DiretorOutputGetAllDto>> Get() {
        var diretores = await _context.Diretores.ToListAsync();

        var outputDTOList = new List<DiretorOutputGetAllDto>();

        foreach (Diretor diretor in diretores) {
            outputDTOList.Add(new DiretorOutputGetAllDto(diretor.Id, diretor.Nome));
        }

        return outputDTOList;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<DiretorOutputGetByIdDto>> Get(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);

        var outputDto = new DiretorOutputGetByIdDto(diretor.Id, diretor.Nome);

        return Ok(diretor);
    }

    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post([FromBody] DiretorInputPostDTO diretorInputPostDto)
    {
        var diretor = new Diretor(diretorInputPostDto.Nome);
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();
        var diretorOutputPostDTO = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);
        return Ok(diretor);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DiretorOutputPostDTO>> Put(long id, [FromBody] DiretorInputPutDTO diretorInputPutDTO)
    {
        var diretor = new Diretor(diretorInputPutDTO.Nome);
        diretor.Id = id;
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();

        var diretorOutputDto = new DiretorOutputPutDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
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