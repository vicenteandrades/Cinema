using APIFilmeStudy.DTO.Read;
using APIFilmeStudy.DTO.Send;
using APIFilmeStudy.Model;
using APIFilmeStudy.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIFilmeStudy.Controllers;
[Route("[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly EnderecoRepository _repository;
    private readonly IMapper _mapper;

    public EnderecoController(EnderecoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadEnderecoDto>>> GetAsync()
    {
        var list = await _repository.GetAsync();

        var listDto = _mapper.Map<IEnumerable<ReadEnderecoDto>>(list);

        return (listDto.Any()) ? Ok(listDto) : NotFound("Ainda não há endereços cadastrados!"); 
    }

    [HttpGet ("{id}", Name = "GetEnderecoId")]
    public async Task<ActionResult<ReadEnderecoDto>> GetByIdAsync(int id)
    {
        var endereco = _repository.GetByIdAsync(id);

        var enderecoDto = _mapper.Map<ReadFilmeDto>(endereco);

        return (enderecoDto is not null) ? Ok(enderecoDto) : NotFound("Endereço não encontrado") ;
    }

    [HttpPost]
    public ActionResult Post([FromBody] SendEnderecoDto enderecoDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var endereco = _mapper.Map<Endereco>(enderecoDto);
        _repository.Create(endereco);
        return CreatedAtRoute("GetEnderecoId", new { id = endereco.EnderecoId}, endereco);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] SendEnderecoDto enderecoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var endereco = _repository.GetById(id);

        if (endereco is null)
            return NotFound("Endereço não encontrado");


        _mapper.Map(enderecoDto, endereco);
        _repository.Update(endereco);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult Patch(int id, [FromBody] JsonPatchDocument<SendEnderecoDto> patch)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var endereco = _repository.GetById(id);
        if (endereco is null)
            return NotFound("Endereço não encontrado");

        var enderecoDto = _mapper.Map<SendEnderecoDto>(endereco);
        patch.ApplyTo(enderecoDto);

        _mapper.Map(enderecoDto, endereco);
        _repository.Commit();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var endereco = _repository.GetById(id);
        if (endereco is null)
            return NotFound("Endereço não encontrado");

        _repository.Delete(endereco);
        return NoContent();
    }

}

