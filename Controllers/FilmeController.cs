using APIFilmeStudy.DTO;
using APIFilmeStudy.DTO.Read;
using APIFilmeStudy.Model;
using APIFilmeStudy.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIFilmeStudy.Controllers;
[Route("[controller]")]
[ApiController]
public class FilmeController : ControllerBase
{
    private readonly FilmeRepository _repository;
    private readonly IMapper _mapper;

    public FilmeController(FilmeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadFilmeDto>>> GetAsync()
    {
        var list = await _repository.GetAsync();

        var listDto = _mapper.Map<IEnumerable<ReadFilmeDto>>(list);

        return (listDto.Any()) ? Ok(listDto) : NotFound("Ainda não temos filmes cadastrados, volte em breve!");
    }

    [HttpGet("{id}", Name = "GetFilmeId")]
    public async Task<ActionResult<ReadFilmeDto>> GetByIdAsync(int id)
    {
        var filme = await _repository.GetByIdAsync(id);
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

        return (filmeDto is not null) ? Ok(filmeDto) : NotFound();
    }

    [HttpPost]
    public ActionResult Post([FromBody] SendFilmeDto filmeDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var filme = _mapper.Map<Filme>(filmeDto);

        _repository.Create(filme);
        return CreatedAtRoute("GetFilmeId", new { id = filme.FilmeId}, filme);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] SendFilmeDto filmeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var findFilme = _repository.GetById(id);

        if (findFilme is null)
        {
            return NotFound();
        }

        _mapper.Map(filmeDto, findFilme);

        _repository.Update(findFilme);
        return Ok();
    }

    [HttpPatch("{id}")]
    public ActionResult Patch(int id, JsonPatchDocument<SendFilmeDto> patch)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        var filme = _repository.GetById(id);
        var filmeDto = _mapper.Map<SendFilmeDto>(filme);

        if(filme is null)
        {
            return NotFound("Não encontramos o filme");
        }

        patch.ApplyTo(filmeDto);

        _mapper.Map(filmeDto, filme);
        _repository.Commit();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {

        var findFilme = _repository.GetById(id);
        if (findFilme is null)
        {
            return NotFound();
        }

        _repository.Delete(findFilme);
        return Ok();
    }
    

}

