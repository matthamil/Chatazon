using System.ComponentModel.DataAnnotations;

namespace Chatazon.Models
{
    public class NewMessageViewModel
    {
        [Required]
        public string Content { get; set; }
    }
}