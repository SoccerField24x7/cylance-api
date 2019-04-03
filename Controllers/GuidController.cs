using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using CylanceContext.Entities;
using GUID = CylanceContext.Entities.Guid;
using Microsoft.Extensions.Caching.Distributed;
using ServiceStack.Redis;
using Newtonsoft.Json;

namespace Cylance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidController : ControllerBase
    {
        // GET api/guid
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // get the Guid here
            System.Guid newObj = new System.Guid("8214d430-301e-446f-88b7-e218677ae2bf");
            GUID thisGuid;

            using (var redis = new RedisClient())
            {
                thisGuid = redis.GetById<GUID>(newObj);

                if (thisGuid == null)
                {
                    using (var context = new CylanceDBContext())
                    {
                        var result = context.Guids.Where(x => x.Id == newObj).FirstOrDefault();

                        if (result != null)
                        {
                            var redisGuids = redis.As<GUID>();
                            redisGuids.Store(result);
                        }
                    }
                }
            }

            return Content(JsonConvert.SerializeObject(thisGuid));
        }

        // GET api/guid/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/guid
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/guid/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/guid/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
