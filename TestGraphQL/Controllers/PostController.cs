using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tiktack.WebGraphQL.BusinessLayer;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace TestGraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostProvider _postProvider;

        public PostController(IPostProvider postProvider)
        {
            _postProvider = postProvider;
        }

        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return _postProvider.GetAll();
        }

        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return _postProvider.GetById(id);
        }
    }
}