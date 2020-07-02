using System;
using System.Collections.Generic;
using DTT_Test.Models;

namespace DTT_Test.Repositories
{
    public interface IArticleRepository
    {
        Article GetById(int id);
        IEnumerable<Article> GetAll();
        IEnumerable<Article> GetRecentArticles();
        void Add(Article entity);
        void Delete(Article article);
        void Edit(Article entity);
        bool ArticleExists(int id);
        void Save();
    }
}
