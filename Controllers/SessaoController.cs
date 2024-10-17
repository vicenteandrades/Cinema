using APIFilmeStudy.DTO.Read;
using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using APIFilmeStudy.Repository;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIFilmeStudy.Controllers;

[Route("[Controller]")]
[ApiController]
public class SessaoController : ControllerBase
{
    private readonly SessaoRepository _repository;
    private readonly IMapper _mapper;

    public SessaoController(SessaoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadSessaoDto>>> GetAsync()
    {
        var list = await _repository.GetAsyncComplete();
        var listDto = _mapper.Map<IEnumerable<ReadSessaoDto>>(list);
        return (listDto.Any()) ? Ok(listDto) : NotFound("Ainda não temos sessões cadastradas!");
    }

    [HttpGet("{id}", Name = "GetSessaoId")]
    public async Task<ActionResult<ReadSessaoDto>> GetByIdAsync(int id)
    {
        var sessao = await _repository.GetByIdAsync(id);

        return (sessao is not null) ? Ok(sessao) : NotFound("Sessão não encontrada");
    }

    [HttpPost]
    public ActionResult Post([FromBody] SendSessaoDto sessaoDto)
    {
        var sessao = _mapper.Map<Sessao>(sessaoDto);

        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _repository.Create(sessao);
        return CreatedAtRoute("GetSessaoId", new { id = sessao.SessaoId}, sessao);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] SendSessaoDto sessaoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var findsessao = _repository.GetById(id);

        if (findsessao is null) 
        {
            return NotFound("Sessão não encontrada");
        }

        _mapper.Map(sessaoDto, findsessao);
        _repository.Update(findsessao);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult Patch(int id, JsonPatchDocument<SendSessaoDto> patch)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var sessao = _repository.GetById(id);

        if(sessao is null)
        {
            return NotFound("Sessão não encontrada.");
        }

        var sessaoDto = _mapper.Map<SendSessaoDto>(sessao);
        patch.ApplyTo(sessaoDto);

        _mapper.Map(sessaoDto, sessao);
        _repository.Commit();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var findSessao = _repository.GetById(id);

        if (findSessao is null)
        {
            return NotFound("Sessão não encontrada.");
        }

        _repository.Delete(findSessao);
        return NoContent();
    }

}

