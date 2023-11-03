using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.DTOs;

namespace BookManagement.Services.BookService
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAll();
        Task<BookDto> Get(int id);
        Task<bool> Create(BookRequestDto newBook);
        Task<bool> Update(int id, BookRequestDto book);
        Task<bool> Delete(int id);
    }
}