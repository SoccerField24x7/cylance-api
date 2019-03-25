using System;
using System.Linq;
using Xunit;
using Microsoft.Extensions.Caching.Distributed;
using CylanceContext.Entities;
//using StackExchange.Redis;

namespace Cylance.Api.Tests
{
    public class WebAPIUnitTests
    {
        private readonly IDistributedCache _cache;

        public WebAPIUnitTests(IDistributedCache distributedCache)
        {
            _cache = distributedCache;
        }

        [Fact]
        public void DatabaseIsAvailable()
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
