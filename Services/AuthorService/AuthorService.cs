using AutoMapper;
using BookManagement.Data;
using BookManagement.DTOs;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AuthorService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Create(AuthorRequestDto newAuthor)
        {
            try 
            {
                var author = _mapper.Map<AuthorRequestDto,Author>(newAuthor);
                await _context.AddAsync(author);
                await _context.SaveChangesAsync();
                return true;
            }
            catch {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var author = await _context.Authors.SingleOrDefaultAsync(u => u.Id == id);
                if (author is null)
                {
                    return false;
                }
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<AuthorDto> Get(int id)
        {
            try 
            {
                var author = await _context.Authors.SingleOrDefaultAsync(u => u.Id == id);
                var authorDto = _mapper.Map<AuthorDto>(author);
                return authorDto;
            }
            catch
            {
                throw new Exception("Some thing went wrong.");
            }
        }

        public async Task<List<AuthorDto>> GetAll()
        {
            try
            {
                var authors = await _context.Authors.ToListAsync();
                var authorDtos = _mapper.Map<List<Author>, List<AuthorDto>>(authors);
                return authorDtos;
            }
            catch
            {
                throw new Exception("Some thing went wrong.");
            }
        }

        public async Task<bool> Update(int id, AuthorRequestDto author)
        {
            try
            {
                var oldAuthor = await _context.Authors.Include(u => u.Books).SingleOrDefaultAsync(b => b.Id == id);
                if (oldAuthor is null) 
                {
                    return false;
                }
                _mapper.Map(author, oldAuthor);
                _context.Attach(oldAuthor);
                await _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}