using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController: ControllerBase
    {
        private readonly IMusicRepository _repository;
        private readonly ILogger<MusicController> _logger;
        
        public MusicController(ILogger<MusicController> logger, IMusicRepository repo)
        {
            _logger = logger;
            _repository = repo;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType( StatusCodes.Status201Created)]
        public async Task<ActionResult<Music>> CreateMusic(Music m)
        {
            if (m.Id != 0) //New music shouldn't have an Id
            {
                return Conflict(); //TODO: Search if this status code is correct. Shouldn't this be 422 Unprocessable Entity?
            }

            await _repository.CreateMusic(m);
            
            return CreatedAtAction(nameof(GetMusicById), new { id = m.Id }, m);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Music>> GetMusicById(int id)
        {
            Music m = await _repository.GetMusic(id);
            if (m == null)
            {
                return NotFound();
            }

            return m;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IAsyncEnumerable<Music>>> GetAllMusics()
        {
            //TODO: Don't know if I'm using the IAsyncEnumerable correctly. There's some tips on 
            //  https://stackoverflow.com/questions/62731425/how-to-use-iasyncenumerable-in-repository-class   
            return Ok(await _repository.GetAllMusics());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Music>> UpdateMusic(int id, Music m)
        {
            Music ms = await _repository.GetMusic(id);
            if (ms == null)
            {
                Music newMusic = await _repository.CreateMusic(m); 
                
                return CreatedAtAction(nameof(GetMusicById), new {id = newMusic.Id}, newMusic);
            }
            await _repository.UpdateMusic(m);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Music>> DeleteMusic(int id)
        {
            Music ms = await _repository.GetMusic(id);
            if (ms == null)
            {
                return NotFound();
            }

            await _repository.DeleteMusic(ms);

            return NoContent();
        }

    }
}