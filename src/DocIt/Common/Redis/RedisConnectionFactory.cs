using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;

namespace DocIt.Common.Redis
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        /// <summary>
        ///     The _connection.
        /// </summary>
        private readonly Lazy<ConnectionMultiplexer> _connection;

        private readonly RedisConfig _redisConfig;

        public RedisConnectionFactory(IOptions<RedisConfig> redisConfig)
        {
            _redisConfig = redisConfig.Value;
            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_redisConfig.FullAddress));
        }

        public ConnectionMultiplexer Connection()
        {
            return _connection.Value;
        }
    }
}
