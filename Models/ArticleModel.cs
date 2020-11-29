using System;
using System.ComponentModel.DataAnnotations;

namespace DevBlog.Models
{
    public record ArticleModel
    {
        [Key]
        public int Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }

        public string Category { get; init; }

        public string ImageUrl { get; init; }

        public DateTime PublishDate { get; init; }

        public short ReadingTime { get; init; }

        public short NumberOfComments { get; init; }

        public ArticleModel(int id, string title, string description, string category, string imageUrl, DateTime publishDate, short readingTime, short numberOfComments)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            ImageUrl = imageUrl;
            PublishDate = publishDate;
            ReadingTime = readingTime;
            NumberOfComments = numberOfComments;
        }
    }
}
