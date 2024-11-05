using Microsoft.AspNetCore.Mvc;
using SustenAI.API.Services.Recommendation;

namespace SustenAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationService _recommendationService;

        public RecommendationController(RecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpPost("treinar")]
        public IActionResult Treinar([FromBody] List<ProductRating> avaliacoes)
        {
            _recommendationService.TrainModel(avaliacoes);
            return Ok("Modelo treinado com sucesso!");
        }

        [HttpGet("prever")]
        public IActionResult Prever(string idUsuario, string idProduto)
        {
            var pontuacao = _recommendationService.PreverPontuacao(idUsuario, idProduto);
            return Ok(new { idUsuario, idProduto, pontuacao });
        }
    }
}