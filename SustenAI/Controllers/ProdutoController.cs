using Microsoft.AspNetCore.Mvc;
using SustenAI.Models;
using SustenAI.Repository;

namespace SustenAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> BuscarTodosProdutos()
        {
            List<Produto> produtos = await _produtoRepository.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> BuscarPorId(int id)
        {
            Produto produto = await _produtoRepository.BuscarPorId(id);
            if (produto == null)
            {
                return NotFound($"Produto com ID {id} não encontrado.");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Cadastrar([FromBody] Produto produtoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Produto produto = await _produtoRepository.Adicionar(produtoModel);
            return CreatedAtAction(nameof(BuscarPorId), new { id = produto.IdProd }, produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Atualizar([FromBody] Produto produtoModel, int id)
        {
            try
            {
                Produto produtoAtualizado = await _produtoRepository.Atualizar(produtoModel, id);
                return Ok(produtoAtualizado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            try
            {
                bool apagado = await _produtoRepository.Apagar(id);
                return Ok(new { sucesso = apagado, mensagem = "Produto apagado com sucesso!" });
    
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}