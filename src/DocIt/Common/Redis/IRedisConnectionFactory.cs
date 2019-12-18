using StackExchange.Redis;

namespace DocIt.Common.Redis
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
    }
}
