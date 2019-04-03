using System;
using System.Linq;
using Xunit;
using CylanceContext.Entities;
using GUID = CylanceContext.Entities.Guid;
using ServiceStack.Redis;
using CylanceApi.BusinessLogic;

namespace Cylance.Api.Tests
{
    public class WebAPIUnitTests
    {
        [Fact]
        public void SQLDatabaseIsAvailable()
        {
            bool valid;
            try
            {
                using (var context = new CylanceDBContext())
                {
                    var result = context.Guids.FirstOrDefault();
                }
                valid = true;
            }
            catch (Exception)
            {
                valid = false;
            }

            Assert.True(valid);
        }

        [Fact]
        public void NoSQLDatabaseIsAvailable()
        {
            bool valid;
            using (var redis = new RedisClient())
            {
                var redisGuids = redis.As<GUID>();

                var testGuid = new GUID
                {
                    Id = System.Guid.NewGuid(),
                    //GUID = System.Guid.NewGuid(),
                    Author = "Random",
                    Title = "dunno"
                };

                try
                {
                    redisGuids.Store(testGuid);
                    valid = true;
                }
                catch(Exception)
                {
                    valid = false;
                }

                //var gg = redisGuids.GetById(testGuid.Id);

                //string blah = "HI";
                
            }

            Assert.True(valid);
        }

        [Fact(Skip = "TDD: Not yet available")]
        public void EndpointsAreAvailable()
        {

        }

        [Fact(Skip = "TDD: Not yet available")]
        public void ContactAPIEndpointGenerates401()
        {


        }

        [Fact(Skip = "TDD: Not yet available")]
        public void ContactAPIEndpointSuccess()
        {

        }

        [Fact(Skip = "TDD: Not yet available")]
        public void CreateGuidSuccess()
        {

        }

        [Fact(Skip = "TDD: Not yet available")]
        public void CreateGuidFail()
        {

        }

        [Fact(Skip = "TDD: Not yet available")]
        public void PatchGuidSuccess()
        {

        }

        [Fact(Skip = "TDD: Not yet available")]
        public void PatchGuidFailsValidation()
        {

        }

        [Fact(Skip = "TDD: Not yet available")]
        public void DeleteGuidSuccess()
        {

        }

        [Fact(Skip = "TDD: Not yet available")]
        public void DeleteGuidIsIdempotent()
        {

        }
    }
}
