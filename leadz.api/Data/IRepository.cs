using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leadz.Api.Data
{
	public interface IRepository<TEntity>
		where TEntity : class, IEntity
	{
		Task<IEnumerable<TEntity>> GetAll();

		Task<TEntity> GetById(int id);

		Task Create(TEntity entity);

		Task Update(int id, TEntity entity);

		Task Delete(int id);
	}
}