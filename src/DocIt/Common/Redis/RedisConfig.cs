namespace DocIt.Common.Redis
{
    public class RedisConfig
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string Name { get; set; }

        public string FullAddress => $"{Host}:{Port}";
    }
}
