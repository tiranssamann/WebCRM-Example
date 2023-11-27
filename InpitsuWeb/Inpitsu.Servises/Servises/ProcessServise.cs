using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inpitsu.Data.DtoObjects;
using Inpitsu.Filters;
using Inpitsu.Servises.Interfaces;
using Inpitsu.Repositories.Interfaces;
using AutoMapper;
using Inpitsu.Data.Models;
using Inpitsu.Logger;

namespace Inpitsu.Servises.Servises
{
    public class ProcessServise : IProcessServise
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ProcessServise(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public ProcessDto CreateProcess(ProcessCreateDto process)
        {
            var processEntity = _mapper.Map<Process>(process);

            _repository.ProcessRepository.CreateProcessSetting(processEntity);
            _repository.Save();

            var result = _mapper.Map<ProcessDto>(processEntity);

            return result;
        }

        public void DeleteProcess(Guid Id, bool trackChanges)
        {
            var processes = _repository.ProcessRepository.GetProcess(Id, trackChanges);
            if (processes is null)
                throw new Exception();

            _repository.ProcessRepository.DeleteProcess(processes);
            _repository.Save();
        }

        public IEnumerable<ProcessDto> GetAll(bool trackChanges, PaginationFilter filter)
        {
            try
            {
                var processes = _repository.ProcessRepository.GetAll(trackChanges, filter);
                var processesDto = _mapper.Map<IEnumerable<ProcessDto>>(processes);
                return processesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAll)} service method {ex}");
                throw;
            }
        }


        public ProcessDto GetProcess(Guid Id, bool trackChanges)
        {
            var process = _repository.ProcessRepository.GetProcess(Id, trackChanges);
            return _mapper.Map<ProcessDto>(process);
        }

        public int GetProcessCount(bool trackChanges)
        {
            return _repository.ProcessRepository.GetCount(trackChanges);
        }

        public void UpdateProcess(ProcessUpdateDto process)
        {
            throw new NotImplementedException();
        }
    }
}
