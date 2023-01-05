using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductFeedback.API.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Image { get; set; }

        public User(string userName, string image)
        {
            UserName = userName;
            Image = image;
        }
    }
}
