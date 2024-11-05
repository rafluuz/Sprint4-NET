using Microsoft.AspNetCore.Mvc;
using SustenAI.Models;
using SustenAI.Repository;

namespace SustenAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrevisaoController : ControllerBase
    {
        private readonly IPrevisaoRepository _previsaoRepository;

        public PrevisaoController(IPrevisaoRepository previsaoRepository)
        {
            _previsaoRepository = previsaoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Previsao>>> BuscarTodasPrevisoes()
        {
            List<Previsao> previsoes = await _previsaoRepository.BuscarTodasPrevisoes();
            return Ok(previsoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Previsao>> BuscarPorId(int id)
        {
            Previsao previsao = await _previsaoRepository.BuscarPorId(id);
            if (previsao == null)
            {
                return NotFound($"Previsão com ID {id} não foi encontrada.");
            }
            return Ok(previsao);
        }

        [HttpPost]
        public async Task<ActionResult<Previsao>> Cadastrar([FromBody] Previsao previsaoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Previsao previsao = await _previsaoRepository.Adicionar(previsaoModel);
            return Ok(previsao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Previsao>> Atualizar([FromBody] Previsao previsaoModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Previsao previsaoAtualizada = await _previsaoRepository.Atualizar(previsaoModel, id);
            if (previsaoAtualizada == null)
            {
                return NotFound($"Previsão com ID {id} não foi encontrada.");
            }

            return Ok(previsaoAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _previsaoRepository.Apagar(id);
            if (!apagado)
            {
                return NotFound($"Previsão com ID {id} não foi encontrada.");
            }

            return Ok(apagado);
        }
    }
}