using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leadz.Api.Data
{
	public class EFRepo<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity
	{
		private readonly Context _dbContext;

		public EFRepo(Context dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await _dbContext.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetById(int id)
		{
			return await _dbContext.Set<TEntity>()
			                       .FirstAsync(e => e.Id == id);
		}

		public async Task Create(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Update(int id, TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var entity = await GetById(id);
			_dbContext.Set<TEntity>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}