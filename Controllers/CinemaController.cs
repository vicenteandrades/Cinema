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
public class CinemaController : ControllerBase
{
    private readonly CinemaRepository _repository;
    private readonly IMapper _mapper;

    public CinemaController(CinemaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadCinemaDto>>> GetAsync()
    {
        var list = await _repository.GetAsync();

        var listDto = _mapper.Map<IEnumerable<ReadCinemaDto>>(list);

        return (listDto.Any()) ? Ok(listDto) : NotFound("Ainda não há Cinemas cadastrados!");
    }

    [HttpGet("{id}", Name = "GetCinemaId")]
    public async Task<ActionResult<ReadCinemaDto>> GetByIdAsync(int id)
    {
        var cinema = _repository.GetByIdAsync(id);

        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

        return (cinemaDto is not null) ? Ok(cinemaDto) : NotFound("Cinema não encontrado");
    }

    [HttpPost]
    public ActionResult Post([FromBody] SendCinemaDto cinemaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var cinema = _mapper.Map<Cinema>(cinemaDto);
        _repository.Create(cinema);
        return CreatedAtRoute("GetCinemaId", new { id = cinema.CinemaId }, cinema);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] SendCinemaDto cinemaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var cinema = _repository.GetById(id);

        if (cinema is null)
            return NotFound("Endereço não encontrado");


        _mapper.Map(cinemaDto, cinema);
        _repository.Update(cinema);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult Patch(int id, [FromBody] JsonPatchDocument<SendCinemaDto> patch)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var cinema = _repository.GetById(id);

        if (cinema is null)
            return NotFound("Endereço não encontrado");


        var cinemaDto = _mapper.Map<SendCinemaDto>(cinema);
        patch.ApplyTo(cinemaDto);

        _mapper.Map(cinemaDto, cinema);
        _repository.Commit();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var cinema = _repository.GetById(id);
        if (cinema is null)
            return NotFound("Endereço não encontrado");

        _repository.Delete(cinema);
        return NoContent();
    }

}

