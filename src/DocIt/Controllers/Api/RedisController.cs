using DocIt.Common.Redis;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace DocIt.Controllers.Api
{
    [Route("api/v1/[controller]")]
    public class RedisController : ControllerBase
    {
        private IDatabase RedisDatabase { get; set; }

        public RedisController(IRedisConnectionFactory redisConnectionFactory)
        {
            RedisDatabase = redisConnectionFactory.Connection().GetDatabase();
        }

        [HttpGet]
        [Route("{key}")]
        public async Task<IActionResult> GetByKey(string key)
        {
            return Json(new
            {
                Key = key,
                Value = await RedisDatabase.StringGetAsync(key)
            });
        }
    }
}
