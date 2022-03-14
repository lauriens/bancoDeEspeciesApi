using AutoMapper;
using BancoDeEspecies.Application.ViewModels;
using BancoDeEspecies.Domain.Models;

namespace BancoDeEspecies.Application.Mappings
{
    public class LocalidadeMap : Profile
    {
        public LocalidadeMap()
        {
            CreateMap<Localidade, LocalidadeViewModel>();
        }
    }
}
