using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.DTOs
{
    public class AuthorRequestDto
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}