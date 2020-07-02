using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTT_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace DTT_Test.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DTTContext _context;

        public ArticleRepository(DTTContext context)
        {
            _context = context;
        }

        public async Task<Article> GetById(int id)
        {
            return await _context.Article.FindAsync(id);
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _context.Article
                .OrderByDescending(a => a.PublishDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetRecentArticles()
        {
            return await _context.Article
                .OrderByDescending(a => a.PublishDate)
                .Take(5)
                .ToListAsync();
        }

        public async Task<bool> ArticleExists(int id)
        {
            return await _context.Article.AnyAsync(e => e.Id == id);
        }

        public async Task Create(Article article)
        {
            _context.Article.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Article article)
        {
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
