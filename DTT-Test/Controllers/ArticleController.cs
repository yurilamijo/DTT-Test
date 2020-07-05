using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTT_Test.Models;
using Microsoft.AspNetCore.Authorization;
using DTT_Test.Helpers;
using DTT_Test.Repositories;
using System.Threading.Tasks;

namespace DTT_Test.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _artcileRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _artcileRepository = articleRepository;
        }

        // GET: api/Archive
        [AllowAnonymous]
        [HttpGet("/api/archive")]
        public async Task<IEnumerable<Article>> GetArticleAsync()
        {            
            // Returns every article
            return await _artcileRepository.GetAll();
        }

        // GET: api/articles
        [AllowAnonymous]
        [HttpGet("/api/articles")]
        public async Task<IEnumerable<Article>> GetSumOfArticleAsync()
        {
            // Returns the 5 most recents articles
            return await _artcileRepository.GetRecentArticles();
        }

        // GET: api/Article/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Article>> GetArticleAsync(int id)
        {
            // Gets the article by id
            var article = await _artcileRepository.GetById(id);

            // Checks if article exists
            if (article == null)
            {
                // return error message if there was an exception
                return NotFound();
            }

            // Returns the founded article
            return article;
        }

        // PUT: api/Article/5
        [HttpPut("{id}")]
        [AuthorizeRoles(Role.Admin, Role.User)]
        public async Task<IActionResult> PutArticleAsync(int id, [Bind("Title, Summary, Description, PublishDate")] Article article)
        {
            // Checks if it's the right article
            if (id != article.Id)
            {
                // return error message if there was an exception
                return BadRequest(new { message = "Given id article is not the same of the article object" });
            }

            // Checks if the model is valid
            if (ModelState.IsValid)
            {
                try
                {
                    // Inserts changed data
                    await _artcileRepository.Update(article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _artcileRepository.ArticleExists(id))
                    {
                        // return error message if there was an exception
                        return NotFound(new { message = "Given article not found" });
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                return BadRequest(new { message = "Given changes are not accepted" });
            }

            // return error message if there was no article
            return NoContent();
        }

        // POST: api/Article
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<Article>> PostArticleAsync([Bind("Title, Summary, Description, PublishDate")] Article article)
        {
            // Checks if the model is valid
            if (ModelState.IsValid)
            {
                // Adds the artcile to the database
                await _artcileRepository.Create(article);
                return CreatedAtAction("GetArticle", new { id = article.Id }, article);
            }

            // return error message if there was no article
            return NoContent();
        }

        // DELETE: api/Article/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<Article>> DeleteArticleAsync(int id)
        {
            // Gets the article by id
            var article = await _artcileRepository.GetById(id);
            // Checks if the article exists
            if (article == null)
            {
                // return error message if there was no article
                return NotFound(new { message = "Given article not found" });
            }

            // Deletes the article form the database
            await _artcileRepository.Delete(article);
            return article;
        }
    }
}
