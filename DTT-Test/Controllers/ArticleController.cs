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

namespace DTT_Test.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly DTTContext _context;

        public ArticleController(DTTContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: api/Archive
        [HttpGet("/api/archive")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticle()
        {
            // Gets every article
            return await _context.Article
                .OrderByDescending(a => a.PublishDate)
                .ToListAsync();
        }

        [AllowAnonymous]
        // GET: api/articles
        [HttpGet("/api/articles")]
        public async Task<ActionResult<IEnumerable<Article>>> GetSumOfArticle()
        {
            // Gets the 5 most recents articles
            return await _context.Article
                .OrderByDescending(a => a.PublishDate)
                .Take(5)
                .ToListAsync();
        }

        // GET: api/Article/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            // Gets the article by id
            var article = await _context.Article.FindAsync(id);

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
        public async Task<IActionResult> PutArticle(int id, [Bind("Title, Summary, Description, PublishDate")] Article article)
        {
            // Checks if it's the right article
            if (id != article.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // Inserts changed data
                _context.Entry(article).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(id))
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
        public async Task<ActionResult<Article>> PostArticle([Bind("Title, Summary, Description, PublishDate")] Article article)
        {
            if (ModelState.IsValid) {
                // Adds the artcile to the database
                _context.Article.Add(article);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetArticle", new { id = article.Id }, article);
            }

            return NoContent();
        }

        // DELETE: api/Article/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<Article>> DeleteArticle(int id)
        {
            // Gets the article by id
            var article = await _context.Article.FindAsync(id);
            // Checks if the article exists
            if (article == null)
            {
                return NotFound();
            }

            // Deletes the article form the database
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();

            return article;
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Id == id);
        }
    }
}
