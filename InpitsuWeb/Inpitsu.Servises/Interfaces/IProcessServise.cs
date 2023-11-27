using Inpitsu.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inpitsu.Data.DtoObjects;
namespace Inpitsu.Servises.Interfaces
{
    public interface IProcessServise
    {
        IEnumerable<ProcessDto> GetAll(bool trackChanges, PaginationFilter filter);
        ProcessDto GetProcess(Guid Id, bool trackChanges);
        ProcessDto CreateProcess(ProcessCreateDto process);
        void DeleteProcess(Guid Id, bool trackChanges);
        void UpdateProcess(ProcessUpdateDto process);
        public int GetProcessCount(bool trackChanges);
    }
}
