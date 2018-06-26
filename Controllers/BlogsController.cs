using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogPosts.Data;
using BlogPosts.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogPostsContext _db;
        public BlogsController(BlogPostsContext db) => _db = db;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            return _db.Blogs
                .Include(b => b.Posts)
                .ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            return _db.Blogs
                .Include(b => b.Posts)
                .SingleOrDefault(b => b.BlogId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
