namespace BancoDeEspecies.Domain.Models
{
    public class Localidade
    {
        public int Id { get; set; }
        public Cidade? Cidade { get; set; }
        public Estado? Estado { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
