using APIFilmeStudy.Model;
using APIFilmeStudy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFilmeStudy.Controllers;
[Route("[controller]")]
[ApiController]
public class FilmeController : ControllerBase
{
    private readonly FilmeRepository _repository;

    public FilmeController(FilmeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Filme>>> GetAsync()
    {
        var list = await _repository.GetAsync();

        return (list.Any()) ? Ok(list) : NotFound("Ainda não temos filmes cadastrados, volte em breve!");
    }

    [HttpGet("{id}", Name = "GetFilmeId")]
    public async Task<ActionResult<Filme>> GetByIdAsync(int id)
    {
        var filme = await _repository.GetByIdAsync(id);
        return (filme is not null) ? Ok(filme) : NotFound();
    }

    [HttpPost]
    public ActionResult Post([FromBody] Filme filme)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _repository.Create(filme);
        return CreatedAtRoute("GetFilmeId", new { id = filme.FilmeId}, filme);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Filme filme)
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

        findFilme.Titulo = filme.Titulo;
        findFilme.Genero = filme.Genero;
        findFilme.Duracao = filme.Duracao;

        _repository.Update(findFilme);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
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

        _repository.Delete(findFilme);
        return Ok();
    }
    

}

