using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi.Models.Entities;

namespace WebApi.Contexts
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<CommentEntity> Comments { get; set; }
	}
}
