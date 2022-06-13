using Crud.domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.EF.Services
{
    public class GenericDataService<T> : IDataService<T> where T : class
    {
        private readonly ClientContextFactory _clientContextFactory;
        private readonly NonqueryDataService<T> _nonqueryDataService;
        public GenericDataService(ClientContextFactory clientContextFactory)
        {
            _clientContextFactory = clientContextFactory;
            _nonqueryDataService = new NonqueryDataService<T>(clientContextFactory);
        }
        public async Task<T> Create(T entity)
        {
            return await _nonqueryDataService.Create(entity);
        }

        public async Task<bool> Delete(T entity)
        {
            return await _nonqueryDataService.Delete(entity);
        }

        public async Task<T> Get(int id)
        {
            using SoftTradeDBContext context = _clientContextFactory.CreateDbContext();
            return await context.Set<T>().FindAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using SoftTradeDBContext context = _clientContextFactory.CreateDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            return await _nonqueryDataService.Update(entity);
        }
    }
}
