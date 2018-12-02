using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private string _redisKey = "test-key";
        private readonly IDatabase _db;
        
        public RedisController(IConnectionMultiplexer redisConnection)
        {
            _db = redisConnection.GetDatabase();
        }
        
        // GET api/redis
        [HttpGet]
        public ActionResult<string> Get()
        {
            RedisValue value = _db.StringGet(_redisKey);
            
            return value.HasValue ? value.ToString() : string.Empty;
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