namespace SustenAI.Models
{
    public class Previsao
    {
        public int IdPrev { get; set; }
        public int IdProd { get; set; }

        public decimal PrecisaoPrev{ get; set; }
        public DateTime DataHoraPrev { get; set; }
        public DateTime UltimaAtt { get; set; }
    }
}