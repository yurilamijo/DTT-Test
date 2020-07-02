using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTT_Test.Models;
using Microsoft.AspNetCore.Authorization;
using DTT_Test.Helpers;
using DTT_Test.Repositories;

namespace DTT_Test.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticleRepository _artcileRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            this._artcileRepository = articleRepository;
        }

        // GET: api/Archive
        [AllowAnonymous]
        [HttpGet("/api/archive")]
        public IEnumerable<Article> GetArticle()
        {            
            return _artcileRepository.GetAll();
        }

        // GET: api/articles
        [AllowAnonymous]
        [HttpGet("/api/articles")]
        public IEnumerable<Article> GetSumOfArticle()
        {
            // Gets the 5 most recents articles
            return _artcileRepository.GetRecentArticles();
        }

        // GET: api/Article/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Article> GetArticle(int id)
        {
            // Gets the article by id
            var article = _artcileRepository.GetById(id);

            // Checks if article exists
            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        // PUT: api/Article/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [AuthorizeRoles(Role.Admin, Role.User)]
        public IActionResult PutArticle(int id, [Bind("Title, Summary, Description, PublishDate")] Article article)
        {
            // Checks if it's the right article
            if (id != article.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Inserts changed data
                    _artcileRepository.Edit(article);
                    _artcileRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_artcileRepository.ArticleExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NoContent();
        }

        // POST: api/Article
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public ActionResult<Article> PostArticle([Bind("Title, Summary, Description, PublishDate")] Article article)
        {
            if (ModelState.IsValid)
            {
                // Adds the artcile to the database
                _artcileRepository.Add(article);
                _artcileRepository.Save();
                return CreatedAtAction("GetArticle", new { id = article.Id }, article);
            }

            return NoContent();
        }

        // DELETE: api/Article/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public ActionResult<Article> DeleteArticle(int id)
        {
            // Gets the article by id
            var article = _artcileRepository.GetById(id);
            // Checks if the article exists
            if (article == null)
            {
                return NotFound();
            }

            // Deletes the article form the database
            _artcileRepository.Delete(article);
            _artcileRepository.Save();
            return article;
        }
    }
}
