using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tiktack.WebGraphQL.Api.GraphQL;

namespace Tiktack.WebGraphQL.Api.Controllers
{
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var result = await _documentExecuter.ExecuteAsync(x =>
            {
                x.Schema = _schema;
                x.Query = query.Query;
                x.Inputs = query.Variables.ToInputs();
            });

            if (result.Errors?.Count > 0)
                return BadRequest(result.Errors);

            return Ok(result);
        }
    }
}