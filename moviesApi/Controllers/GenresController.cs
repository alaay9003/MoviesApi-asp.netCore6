using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moviesApi.Services;

namespace moviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }
         
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Genres = await _genresService.GetAll();
            return Ok(Genres);
        }
        [HttpPost]
        public async Task<IActionResult> CreateASync(CreateGenreDto dto)
        {
            var genre = new Genra { Name=dto.Name };
            await _genresService.Add(genre);
            return Ok(genre);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(byte id ,[FromBody] CreateGenreDto dto )
        {
            var genre = await _genresService.GetById(id);
            if (genre == null)
                return NotFound($"No genre was found with id {id}");

            genre.Name = dto.Name;
            _genresService.Update(genre);
            return Ok(genre);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var genre = await _genresService.GetById(id);
            if (genre == null)
                return NotFound($"No genre was found with id {id}");

            _genresService.Delete(genre);
            return Ok(genre);

        }
    }
}
