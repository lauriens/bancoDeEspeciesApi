namespace BancoDeEspecies.Domain.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Abreviacao { get; set; }
        public IEnumerable<Cidade>? Cidades { get; set;}
    }
}
