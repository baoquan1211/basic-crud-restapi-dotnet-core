using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.DTOs
{
    public class BookRequestDto
    {
        public string? Title { get; set; }
        public int? NumOfPages { get; set; }
        public int? PublicYear { get; set; }
        public string? ISBN { get; set; }
        public List<int>? AuthorIds { get; set; }
    }
}