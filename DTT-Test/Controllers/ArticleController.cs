﻿using System.Collections.Generic;
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
            return await _artcileRepository.GetAll();
        }

        // GET: api/articles
        [AllowAnonymous]
        [HttpGet("/api/articles")]
        public async Task<IEnumerable<Article>> GetSumOfArticleAsync()
        {
            // Gets the 5 most recents articles
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
                return NotFound();
            }

            return article;
        }

        // PUT: api/Article/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [AuthorizeRoles(Role.Admin, Role.User)]
        public async Task<IActionResult> PutArticleAsync(int id, [Bind("Title, Summary, Description, PublishDate")] Article article)
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
                    await _artcileRepository.Update(article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _artcileRepository.ArticleExists(id))
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
        public async Task<ActionResult<Article>> PostArticleAsync([Bind("Title, Summary, Description, PublishDate")] Article article)
        {
            if (ModelState.IsValid)
            {
                // Adds the artcile to the database
                await _artcileRepository.Create(article);
                return CreatedAtAction("GetArticle", new { id = article.Id }, article);
            }

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
                return NotFound();
            }

            // Deletes the article form the database
            await _artcileRepository.Delete(article);
            return article;
        }
    }
}
