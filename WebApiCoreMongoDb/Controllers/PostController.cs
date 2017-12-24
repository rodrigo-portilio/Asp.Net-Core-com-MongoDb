using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreMongoDb.Models;
using MongoDB.Driver;

namespace WebApiCoreMongoDb.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {

        private Context context;

        public PostController()
        {
            context = new Context();
        }

        // GET: api/Post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            var posts = context.Posts.Find(_ => true).ToList();
            return posts;
        }

        // GET: api/Post/5
        [HttpGet("{title}", Name = "Get")]
        public IEnumerable<Post> Get(string title)
        {
            var posts = context.Posts.Find(x => x.Title == title).ToList();
            return posts;
        }
        
        // POST: api/Post
        [HttpPost]
        public void Post([FromBody]Post post)
        {
            context.Posts.InsertOne(post);
        }
        
        // PUT: api/Post/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Post post)
        {
            var filter = Builders<Post>.Filter.Eq(s => s.Id, id);
            var update = Builders<Post>.Update
                            .Set(s => s.Title, post.Title)
                            .Set(s => s.Description, post.Description);

            context.Posts.UpdateOne(filter, update);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            context.Posts.DeleteOneAsync(
                         Builders<Post>.Filter.Eq("Id", id));
        }
    }
}
