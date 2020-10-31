using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rabbit = RabbitMQ.Client;

namespace Classes.IntegrationToolkit
{
    public class RabbitMQ
    {
        public Dictionary<string, string> InboundQueues { get; } = new Dictionary<string, string>()
        {
            { "inbound.Dropoff", "Dropoff_PUT" },
            { "inbound.JobCancel", "JobCancel_PUT" },
            { "inbound.JobRequest", "JobRequest_PUT" },
            { "inbound.JobSegmentModify", "JobSegmentModify_PUT" },
            { "inbound.Pickup", "Pickup_PUT" },
            { "inbound.PickupDropoff", "PickupDropoff_PUT" },
            { "inbound.SubscriptionConfig", "Subscription_PUT" },
        };
        public Dictionary<string, string> OutboundQueues { get; } = new Dictionary<string, string>()
        {
            { "outbound.DataStoreValue", "DataStoreValue_GET" },
            { "outbound.datastore.X (X is any subscribed DataStoreValue)", "DataStoreValue_GET" },
            { "outbound.Dropoff", "Dropoff_GET" },
            { "outbound.Job", "JobMonitoring_GET" },
            { "outbound.JobCancel", "JobCancel_GET" },
            { "outbound.JobRequest", "JobRequest_GET" },
            { "outbound.JobSegment", "" },
            { "outbound.JobSegmentModify", "JobSegmentModify_GET" },
            { "outbound.Pickup", "Pickup_GET" },
            { "outbound.PickupDropoff", "PickupDropoff_GET" },
            { "outbound.Robot", "Robot_GET" },
            { "outbound.RobotFault", "RobotFault_GET" },
            { "outbound.SubscriptionConfig", "Subscription_GET" },
        };
        public string UserName => "toolkitadmin";
        public string ConnectionString(string host, string password) => $"amqps://{UserName}:{password}@{host}/";
        public Rabbit.IConnection Connection { get; private set; }
        public Rabbit.IModel Channel { get; private set; }

        public bool IsException { get; private set; }
        public Exception RabbitMQException { get; private set; }

        private void Reset()
        {
            RabbitMQException = null;
            IsException = false;
        }

        public bool Connect(string host, string password)
        {
            Reset();

            try
            {
                Rabbit.ConnectionFactory factory = new Rabbit.ConnectionFactory { Uri = new Uri(ConnectionString(host, password)) };
                factory.Ssl.AcceptablePolicyErrors = System.Net.Security.SslPolicyErrors.RemoteCertificateNameMismatch | System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors;

                Connection = factory.CreateConnection();

                if(!Connection.IsOpen)
                {
                    Connection.Dispose();
                    Connection = null;
                    return false;
                }


                Channel = Connection.CreateModel();

                return true;
            }
            catch(Exception ex)
            {
                IsException = true;
                RabbitMQException = ex;
                return false;
            }


        }

        public string Get(string queue)
        {
            if(Channel == null) return "";

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            while(true)
            {
                var res = Channel.BasicGet(queue, false);

                if(res == null)
                {
                    if(sb.Length == 1)
                    {
                        return "";
                    }
                    else
                    {
                        sb.Append("]");
                        return sb.ToString();
                    }
                }
                else
                    sb.Append(Encoding.UTF8.GetString(res.Body.ToArray(), 0, res.Body.Length) + ",");
            }
        }
    }
}
