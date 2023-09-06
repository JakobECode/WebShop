using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
	public class CommentRepository : Repository<CommentEntity>
	{
		public CommentRepository(DataContext context) : base(context)
		{
		}
	}
}
