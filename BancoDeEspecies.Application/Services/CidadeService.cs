using AutoMapper;
using BancoDeEspecies.Application.Utilities;
using BancoDeEspecies.Application.ViewModels;
using BancoDeEspecies.DataAccess.Repositories;
using BancoDeEspecies.DataAccess.UnitOfWork;
using BancoDeEspecies.Domain.Models;
using Microsoft.Extensions.Logging;

namespace BancoDeEspecies.Application.Services
{
    public interface ICidadeService
    {
        Task<IEnumerable<CidadeViewModel>> ListAllAsync();
    }

    public class CidadeService : ICidadeService
    {
        private readonly ILogger<CidadeService> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Cidade> _repository;

        public CidadeService(ILogger<CidadeService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;

            _repository = unitOfWork.GetBaseRepository<Cidade>();
        }

        public async Task<IEnumerable<CidadeViewModel>> ListAllAsync()
        {
            var cidades = await _repository.Get(includeProperties: "Estado");

            _logger.LogInformation(Constants.FinishedQueryLog, typeof(Cidade).ToString());

            return cidades.Select(_mapper.Map<CidadeViewModel>);
        }
    }
}
