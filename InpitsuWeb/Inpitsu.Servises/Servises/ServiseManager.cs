using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inpitsu.Data.Models;
using Inpitsu.Logger;
using Inpitsu.Repositories.Interfaces;
using Inpitsu.Servises.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Inpitsu.Servises.Servises
{
    public class ServiseManager : IServiceManager
    {
        private readonly Lazy<IProcessServise> _process;
        private readonly Lazy<IContragentServise> _contragent;
        public ServiseManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            
            _process = new Lazy<IProcessServise>(() => new ProcessServise(repositoryManager,  mapper ,logger));
            _contragent = new Lazy<IContragentServise>(() => new ContragentServise(repositoryManager, mapper, logger));
        }
        public IProcessServise ProcessService => _process.Value;

        public IContragentServise ContragentService => _contragent.Value;
    }
}
