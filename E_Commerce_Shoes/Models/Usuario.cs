namespace E_Commerce_Shoes.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual List<Compra> Compras { get; set; }
    }
}
