using API.Data;
using API.Models;
using API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController: ControllerBase
    {
        private readonly IRepository<Music> _repository;
        private readonly ILogger<MusicController> _logger;
        
        public MusicController(ILogger<MusicController> logger, IRepository<Music> repo)
        {
            _logger = logger;
            _repository = repo;
        }

        [HttpPost]
        [ProducesResponseType( StatusCodes.Status201Created)]
        public async Task<ActionResult<Music>> CreateMusic(MusicDto m)
        {
            var model = m.Map();
            await _repository.Create(model);
            return CreatedAtAction(nameof(GetMusicById), new { id = model.Id }, model);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Music>> GetMusicById(int id)
        {
            Music m = await _repository.Get(id);
            if (m == null)
            {
                return NotFound();
            }

            return Ok(m);
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IAsyncEnumerable<Music>>> GetAllMusics()
        {
            //TODO: Don't know if I'm using the IAsyncEnumerable correctly. There's some tips on 
            //  https://stackoverflow.com/questions/62731425/how-to-use-iasyncenumerable-in-repository-class   
            return Ok(await _repository.GetAll());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Music>> UpdateMusic(int id, MusicDto m)
        {
            Music ms = await _repository.Get(id);
            if (ms == null)
            {
                Music newMusic = await _repository.Create(m.Map()); 
                
                return CreatedAtAction(nameof(GetMusicById), new {id = newMusic.Id}, newMusic);
            }
            
            await _repository.Update(m.Map());
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Music>> DeleteMusic(int id)
        {
            Music ms = await _repository.Get(id);
            if (ms == null)
            {
                return NotFound();
            }

            await _repository.Delete(ms);

            return NoContent();
        }

    }
}