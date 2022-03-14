namespace BancoDeEspecies.Application.ViewModels
{
    public class LocalidadeViewModel
    {
        public int Id { get; set; }
        public CidadeViewModel? Cidade { get; set; }
        public EstadoViewModel? Estado { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
