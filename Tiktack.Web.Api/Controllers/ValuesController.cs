using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiktack.Common.Messaging;
using Tiktack.Web.DataLayer;

namespace Tiktack.Web.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IMessagePublisher messagePublisher, IUnitOfWork unitOfWork, ILogger<ValuesController> logger)
        {
            _messagePublisher = messagePublisher;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("SOME INFO");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            await _messagePublisher.PublishMessageAsync(id.ToString(), id.ToString(), "");
            return "value";
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
