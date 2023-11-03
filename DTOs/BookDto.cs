using System.Threading.Tasks;

namespace BookManagement.DTOs
{
    public class BookDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int? NumOfPages { get; set; }
        public int? PublicYear { get; set; }
        public string? ISBN { get; set; }
        public List<AuthorDto>? Authors { get; set; }
    }
}