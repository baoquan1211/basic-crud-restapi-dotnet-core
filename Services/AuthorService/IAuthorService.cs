using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.DTOs;

namespace BookManagement.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAll();
        Task<AuthorDto> Get(int id);
        Task<bool> Create(AuthorRequestDto newBook);
        Task<bool> Update(int id, AuthorRequestDto book);
        Task<bool> Delete(int id);
    }
}