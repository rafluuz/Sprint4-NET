namespace SustenAI.API.Services.Recommendation
{
    public class ProductRating
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public float Label { get; set; }
    }

    public class ProductPrediction
    {
        public float Score { get; set; }
    }
}