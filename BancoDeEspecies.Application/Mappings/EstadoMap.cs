using AutoMapper;
using BancoDeEspecies.Application.ViewModels;
using BancoDeEspecies.Domain.Models;

namespace BancoDeEspecies.Application.Mappings
{
    public class EstadoMap : Profile
    {
        public EstadoMap()
        {
            CreateMap<Estado, EstadoViewModel>();
        }
    }
}
