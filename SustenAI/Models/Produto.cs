namespace SustenAI.Models
{
    public class Produto
    {
        public int IdProd { get; set; }
        public string NomeProd { get; set; }
        public decimal Preco { get; set; }
        public string Origem { get; set; }
        public string Avaliacao { get; set; }
        public DateTime DataAtual { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAtt { get; set; }
     
    }
}