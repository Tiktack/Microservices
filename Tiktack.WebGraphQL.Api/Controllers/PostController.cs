using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tiktack.WebGraphQL.BusinessLayer;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.Api.Controllers
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