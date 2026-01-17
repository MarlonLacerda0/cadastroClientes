namespace cadastroClientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
        public string? Telefone { get; set; }
        public DateTime DatNascimento { get; set; }
        public DateTime DatCadastro { get; set; } = DateTime.Now;    
    }
}
