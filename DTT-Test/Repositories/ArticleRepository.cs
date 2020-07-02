using System.Collections.Generic;
using System.Linq;
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

        public Article GetById(int id)
        {
            return _context.Article.Find(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Article
                .OrderByDescending(a => a.PublishDate)
                .ToList();
        }

        public IEnumerable<Article> GetRecentArticles()
        {
            return _context.Article
                .OrderByDescending(a => a.PublishDate)
                .Take(5)
                .ToList();
        }

        public void Create(Article article)
        {
            _context.Article.Add(article);
            _context.SaveChanges();
        }

        public void Delete(Article article)
        {
            _context.Article.Remove(article);
            _context.SaveChanges();
        }

        public void Update(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Id == id);
        }
    }
}
