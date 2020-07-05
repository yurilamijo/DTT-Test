using System;
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
            // Finds the article by id
            return await _context.Article.FindAsync(id);
        }

        // Finds every article
        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _context.Article
                .OrderByDescending(a => a.PublishDate)
                .ToListAsync();
        }

        // Finds the 5 most recents articles
        public async Task<IEnumerable<Article>> GetRecentArticles()
        {
            return await _context.Article
                .OrderByDescending(a => a.PublishDate)
                .Take(5)
                .ToListAsync();
        }

        // Checks if the article exists
        public async Task<bool> ArticleExists(int id)
        {
            return await _context.Article.AnyAsync(e => e.Id == id);
        }

        // Creates a new article and saves it in the database
        public async Task Create(Article article)
        {
            _context.Article.Add(article);
            await _context.SaveChangesAsync();
        }

        // Removes the article from the database
        public async Task Delete(Article article)
        {
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
        }

        // Updates the article with the given data and saves it in the database
        public async Task Update(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
