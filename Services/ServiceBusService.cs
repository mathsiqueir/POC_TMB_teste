namespace POC_TMB.Services
{
    public class ServiceBusService
    {
        private readonly ServiceBusService _client;
        private readonly string _queueName;
        private readonly ILogger<ServiceBusService> _logger;

        public ServiceBusService(ServiceBusService client, string queueName, ILogger<ServiceBusService> logger)
        {
            _client = client;
            _queueName = queueName;
            _logger = logger;
        }
    }
}
