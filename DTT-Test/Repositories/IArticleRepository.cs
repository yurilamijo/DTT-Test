using System.Collections.Generic;
using System.Threading.Tasks;
using DTT_Test.Models;

namespace DTT_Test.Repositories
{
    public interface IArticleRepository
    {
        Task<Article> GetById(int id);
        Task<IEnumerable<Article>> GetAll();
        Task<IEnumerable<Article>> GetRecentArticles();
        Task Create(Article entity);
        Task Delete(Article article);
        Task Update(Article entity);
        Task<bool> ArticleExists(int id);
    }
}
