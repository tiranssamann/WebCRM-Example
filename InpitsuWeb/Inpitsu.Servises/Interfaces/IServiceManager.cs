﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Servises.Interfaces
{
    public  interface IServiceManager
    {
        IProcessServise ProcessService { get; }
        IContragentServise ContragentService { get; }
    }
}
