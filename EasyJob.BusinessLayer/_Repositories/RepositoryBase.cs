using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyJob.BusinessLayer._Repositories
{
    public abstract class RepositoryBase<TContext> where TContext: DbContext
    {
        public ILogger<RepositoryBase<TContext>> Logger { get; set; }
        public TContext Context { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public T GetService<T>() => (T) ServiceProvider.GetService(typeof(T));

        public IDbConnection Connection
        {
            get
            {
                var connection = Context.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                return connection;
            }
        }
    }
}