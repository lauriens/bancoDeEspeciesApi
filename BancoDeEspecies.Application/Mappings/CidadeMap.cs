using AutoMapper;
using BancoDeEspecies.Application.ViewModels;
using BancoDeEspecies.Domain.Models;

namespace BancoDeEspecies.Application.Mappings
{
    public class CidadeMap : Profile
    {
        public CidadeMap()
        {
            CreateMap<Cidade, CidadeViewModel>();
        }
    }
}
