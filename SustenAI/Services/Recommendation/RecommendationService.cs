using Microsoft.ML;

namespace SustenAI.API.Services.Recommendation
{

    public class RecommendationService
    {
        private readonly MLContext _mlContext;
        private ITransformer _modelo;

        public RecommendationService()
        {
            _mlContext = new MLContext();
        }

        public void TrainModel(IEnumerable<ProductRating> avaliacoes)
        {
            var dadosTreinamento = _mlContext.Data.LoadFromEnumerable(avaliacoes);

            var pipeline = _mlContext.Transforms
                .Conversion.MapValueToKey("userIdEncoded", nameof(ProductRating.UserId))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("productIdEncoded", nameof(ProductRating.ProductId)))
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(
                    labelColumnName: nameof(ProductRating.Label),
                    matrixColumnIndexColumnName: "userIdEncoded",
                    matrixRowIndexColumnName: "productIdEncoded"));

            _modelo = pipeline.Fit(dadosTreinamento);
        }

        public float PreverPontuacao(string idUsuario, string idProduto)
        {
            var motorPrevisao = _mlContext.Model.CreatePredictionEngine<ProductRating, ProductPrediction>(_modelo);

            var previsao = motorPrevisao.Predict(new ProductRating
            {
                UserId = idUsuario,
                ProductId = idProduto
            });

            
            if (float.IsInfinity(previsao.Score) || float.IsNaN(previsao.Score))
            {
                return 0; 
            }

            return previsao.Score;
        }
    }
}