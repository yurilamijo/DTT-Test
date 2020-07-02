using System;
using System.Collections.Generic;
using System.Linq;
using DTT_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace DTT_Test.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private DTTContext _context;

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

        public void Add(Article article)
        {
            _context.Article.Add(article);
        }

        public void Delete(Article article)
        {
            _context.Article.Remove(article);
        }

        public void Edit(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
        }

        public bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
