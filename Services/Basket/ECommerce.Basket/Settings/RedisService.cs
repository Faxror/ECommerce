using StackExchange.Redis;

namespace ECommerce.Basket.Settings
{
    public class RedisService
    {
        private string _host;
        private int _port;
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect()
        {
            var options = new ConfigurationOptions
            {
                EndPoints = { $"{_host}:{_port}" },
                AbortOnConnectFail = false
            };
            _connectionMultiplexer = ConnectionMultiplexer.Connect(options);
        }

        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(db);
    }
}
