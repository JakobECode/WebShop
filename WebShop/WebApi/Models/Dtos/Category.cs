using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class Category
	{
		public int Id { get; set; }
		public string CategoryName { get; set; } = null!;


		public static implicit operator Category(CategoryEntity entity)
		{
			return new Category()
			{
				Id = entity.Id,
				CategoryName = entity.CategoryName,
			};
		}

		public static implicit operator CategoryEntity(Category category)
		{
			return new CategoryEntity()
			{
				Id = category.Id,
				CategoryName = category.CategoryName,
			};
		}
	}
}
