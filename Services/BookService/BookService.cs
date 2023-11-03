using AutoMapper;
using BookManagement.Data;
using BookManagement.DTOs;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BookService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Create(BookRequestDto newBook)
        {
            List<Author> authors = new List<Author>();
            if (newBook.AuthorIds is not null && newBook.AuthorIds.Count > 0) {
                try {
                    for (int i = 0; i < newBook.AuthorIds.Count(); i++) 
                    {
                        var author = await _context.Authors.SingleOrDefaultAsync(b => b.Id == newBook.AuthorIds[i]);
                        if (author is null)
                            return false;
                        authors.Add(author);
                    }
                }
                catch {
                    return false;
                }
            }
            var book = _mapper.Map<BookRequestDto,Book>(newBook);
            book.Authors = authors;
            try 
            {
                await _context.AddAsync(book);
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
                var book = await _context.Books.Include(b => b.Authors).SingleOrDefaultAsync(b => b.Id == id);
                if (book is null)
                {
                    return false;
                }
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<BookDto> Get(int id)
        {
            try 
            {
                var book = await _context.Books.Include(b => b.Authors).SingleOrDefaultAsync(b => b.Id == id);
                var bookDto = _mapper.Map<BookDto>(book);
                return bookDto;
            }
            catch
            {
                throw new Exception("Some thing went wrong.");
            }
        }

        public async Task<List<BookDto>> GetAll()
        {
            try
            {
                var books = await _context.Books.Include(b => b.Authors).ToListAsync();
                var bookDtos = _mapper.Map<List<Book>, List<BookDto>>(books);
                return bookDtos;
            }
            catch
            {
                throw new Exception("Some thing went wrong.");
            }
        }

        public async Task<bool> Update(int id, BookRequestDto book)
        {
            var oldBook = await _context.Books.Include(b => b.Authors).SingleOrDefaultAsync(b => b.Id == id);
            if (oldBook is null) 
            {
                return false;
            }
            List<Author> authors = new List<Author>();
            if (book.AuthorIds is not null && book.AuthorIds.Count > 0) {
                try {
                    for (int i = 0; i < book.AuthorIds.Count(); i++) 
                    {
                        var author = await _context.Authors.SingleOrDefaultAsync(b => b.Id == book.AuthorIds[i]);
                        if (author is null)
                            return false;
                        authors.Add(author);
                    }
                }
                catch {
                    return false;
                }
            }
            _mapper.Map(book, oldBook);
            oldBook.Authors = authors;
            try
            {
                _context.Attach(oldBook);
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