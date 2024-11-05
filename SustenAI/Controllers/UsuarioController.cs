using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SustenAI.Models;
using SustenAI.Repository;

namespace SustenAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsuarioController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List<Usuario> usuarios = await _userRepository.BuscarTodosUsuarios();
            return Ok(usuarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            Usuario usuario = await _userRepository.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            return Ok(usuario);
        }


        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = await _userRepository.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar([FromBody] Usuario usuarioModel, int id)
        {
            usuarioModel.IdUser = id;
            Usuario usuario = await _userRepository.Atualizar(usuarioModel, id);
            return Ok(usuario);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            try
            {
                bool apagado = await _userRepository.Apagar(id);
                return Ok(new { sucesso = apagado, mensagem = "Usuário apagado com sucesso!" });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);  
            }
        }

    }
}
