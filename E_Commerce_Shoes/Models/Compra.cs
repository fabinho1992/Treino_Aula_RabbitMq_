namespace E_Commerce_Shoes.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public double Preco { get; set; }
        public string Quantidade { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
