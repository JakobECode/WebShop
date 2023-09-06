using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class Comment
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string CommentsText { get; set; } = null!;


		public static implicit operator Comment(CommentEntity entity)
		{
			return new Comment
			{
				Id = entity.Id,
				Name = entity.Name,
				Email = entity.Email,
				CommentsText = entity.CommentsText,
			};
		}

		public static implicit operator CommentEntity(Comment entity)
		{
			return new CommentEntity
			{
				Name = entity.Name,
				Email = entity.Email,
				CommentsText = entity.CommentsText,
			};
		}
	}
}
