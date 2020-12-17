using System;
using ServiceStack.Redis;
using CylanceContext.Entities;
using GUID = CylanceContext.Entities.Guid;

namespace CylanceApi.BusinessLogic
{
    public class GuidBusinessLogic
    {
        private readonly RedisClient _redisClient;
        private readonly CylanceDBContext _context;
        private readonly string errorMessage;

        public GuidBusinessLogic(RedisClient redisClient, CylanceDBContext context)
        {

            if (redisClient == null || context == null)
            {
                throw new Exception("Valid database contexts were not supplied.");
            }

            _redisClient = redisClient;
            _context = context;
        }

        public System.Guid Save(GUID guid)
        {
            if (guid.Id != null && !IsNew(guid.Id))
            {
                return Update(guid);
            }

            if (guid.Id == null)
            {
                guid.Id = System.Guid.NewGuid();
            }

            return System.Guid.NewGuid();
        }

        public System.Guid Update(GUID guid)
        {
            return System.Guid.NewGuid();
        }

        public bool Delete(System.Guid guidId)
        {
            return true;
        }

        public GUID GetGuidById(System.Guid guid)
        {
            return new GUID();
        }

        private bool IsValid(GUID guid)
        {
            return true;
        }

        private bool IsNew(System.Guid guid)
        {
            return true;
        }
    }
}
