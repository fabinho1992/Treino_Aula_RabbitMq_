namespace Aula_RabbitMq.Model
{
    public class Pessoa
    {
        public Pessoa()
        {
            
        }

        public Pessoa(string nome, int idade, string cidade)
        {
            Nome = nome;
            Idade = idade;
            Cidade = cidade;
        }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cidade { get; set; }
    }
}
