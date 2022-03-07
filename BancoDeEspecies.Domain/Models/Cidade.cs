namespace BancoDeEspecies.Domain.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public Estado? Estado { get; set; }
        public IEnumerable<Localidade>? Localidades { get; set; }
    }
}
