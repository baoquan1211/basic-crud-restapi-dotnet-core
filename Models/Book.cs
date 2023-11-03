using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Models
{
    [Index(nameof(ISBN), IsUnique = true)]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        public int NumOfPages { get; set; } = 0;
        public int PublicYear { get; set; }

        [MaxLength(10)]
        public string? ISBN { get; set; }

        [JsonIgnore]
        public List<Author>? Authors { get; set; }
    }
}