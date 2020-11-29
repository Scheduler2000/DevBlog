using System.ComponentModel.DataAnnotations;

namespace DevBlog.Models
{
    

    public record SubscriberModel
    {
        [Key]
        public int Id { get; init; }

        [EmailAddress(ErrorMessage = "Incorrect email address format.")]
        [Required]
        public string Email { get; init; }


        public SubscriberModel(string email)
        {
            Email = email;
        }
    }
}
