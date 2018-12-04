using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using simpleApi.Helpers;
using StackExchange.Redis;

namespace simpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private string _redisKey = "test-key";
        private readonly IDatabase _db;
        private readonly RedisConfig _config;
        
        public RedisController(IConnectionMultiplexer redisConnection, IOptions<RedisConfig> redisConfig)
        {
            _db = redisConnection.GetDatabase();
            _config = redisConfig.Value;
        }
        
        // GET api/redis
        [HttpGet]
        public ActionResult Get()
        {
            RedisValue value = _db.StringGet(_redisKey);
            
            return Ok(new
            {
                Value = (value.HasValue ? value.ToString() : string.Empty),
                RedisHost = _config.Host
            });
        }

        // POST api/values
        [HttpPost]
        public void Post()
        {
            _db.StringIncrement(_redisKey, flags: CommandFlags.FireAndForget);
        }

        // DELETE api/values
        [HttpDelete]
        public void Delete()
        {
            _db.KeyDelete(_redisKey);
        }
    }
}