using AutoMapper;
using BookManagement.DTOs;
using BookManagement.Models;

namespace BookManagement.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Author, AuthorDto>();
            CreateMap<BookRequestDto, Book>();
            CreateMap<AuthorRequestDto, Author>();
        }
    }
}