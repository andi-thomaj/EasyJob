using System;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace EasyJob.BusinessLayer._DataAccessServices
{
    public abstract class CoreBase
    {
        public ILogger<CoreBase> Logger { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public IMapper Mapper { get; set; }
        public T GetService<T>()
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }
    }
}