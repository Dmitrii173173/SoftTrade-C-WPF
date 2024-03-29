﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.EF.Services
{
    public class NonqueryDataService<T> where T : class
    {
        private readonly ClientContextFactory _clientContextFactory;
        private readonly NonqueryDataService<T> _nonqueryDataService;
        public NonqueryDataService(ClientContextFactory clientContextFactory)
        {
            _clientContextFactory = clientContextFactory;
        }
        public async Task<T> Create(T entity)
        {
            using SoftTradeDBContext context = _clientContextFactory.CreateDbContext();
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdResult.Entity;
        }
        public async Task<bool> Delete(T entity)
        {
            using SoftTradeDBContext context = _clientContextFactory.CreateDbContext();
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<T> Update(T entity)
        {
            using SoftTradeDBContext context = _clientContextFactory.CreateDbContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
