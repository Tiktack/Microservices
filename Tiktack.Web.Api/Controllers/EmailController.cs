using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tiktack.Common.Kafka;

namespace Tiktack.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IKafkaProducer _kafkaProducer;

        public EmailController(IKafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        [HttpPost]
        public async Task SendEmail([FromBody] string message)
        {
            await _kafkaProducer.SendAsync(message);
        }

        [HttpGet("{message}")]
        public async Task<string> GetTest(string message)
        {
            
            //_kafkaProducer.Send(message);
            await _kafkaProducer.SendAsync(message);
            return "Done";
        }
    }
}