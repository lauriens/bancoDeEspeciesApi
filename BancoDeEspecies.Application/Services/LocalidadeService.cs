using AutoMapper;
using BancoDeEspecies.Application.Utilities;
using BancoDeEspecies.Application.ViewModels;
using BancoDeEspecies.DataAccess.Repositories;
using BancoDeEspecies.DataAccess.UnitOfWork;
using BancoDeEspecies.Domain.Models;
using Microsoft.Extensions.Logging;

namespace BancoDeEspecies.Application.Services
{
    public interface ILocalidadeService
    {
        Task<IEnumerable<LocalidadeViewModel>> ListAllAsync();
    }

    public class LocalidadeService : ILocalidadeService
    {
        private readonly ILogger<LocalidadeService> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Localidade> _repository;

        public LocalidadeService(ILogger<LocalidadeService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;

            _repository = unitOfWork.GetBaseRepository<Localidade>();
        }

        public async Task<IEnumerable<LocalidadeViewModel>> ListAllAsync()
        {
            var localidades = await _repository.Get(includeProperties: "Cidade,Estado");

            _logger.LogInformation(Constants.FinishedQueryLog, typeof(Localidade).ToString());

            return localidades.Select(_mapper.Map<LocalidadeViewModel>);
        }
    }
}
