using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
	public class ProductEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; } = null!;

		[Required]
		public string Description { get; set; } = null!;

		[Required]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }

		[Range(0, 5)]
		public int StarRating { get; set; } = 0;

		public string? ImageUrl { get; set; }

		public int CategoryId { get; set; }
		public CategoryEntity Category { get; set; } = null!;

		public string? Tag { get; set; }
	}
}
