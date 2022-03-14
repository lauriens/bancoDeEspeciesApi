using AutoMapper;
using BancoDeEspecies.Application.Utilities;
using BancoDeEspecies.Application.ViewModels;
using BancoDeEspecies.DataAccess.Repositories;
using BancoDeEspecies.DataAccess.UnitOfWork;
using BancoDeEspecies.Domain.Models;
using Microsoft.Extensions.Logging;

namespace BancoDeEspecies.Application.Services
{
    public interface IEstadoService
    {
        Task<IEnumerable<EstadoViewModel>> ListAllAsync();
    }

    public class EstadoService : IEstadoService
    {
        private readonly ILogger<EstadoService> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Estado> _repository;

        public EstadoService(ILogger<EstadoService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;

            _repository = unitOfWork.GetBaseRepository<Estado>();
        }

        public async Task<IEnumerable<EstadoViewModel>> ListAllAsync()
        {
            var estados = await _repository.Get();

            _logger.LogInformation(Constants.FinishedQueryLog, typeof(Estado).ToString());

            return estados.Select(_mapper.Map<EstadoViewModel>);
        }
    }
}
