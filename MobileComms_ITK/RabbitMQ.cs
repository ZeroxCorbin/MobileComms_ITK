using MobileComms_ITK.JSON.Types;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Rabbit = RabbitMQ.Client;

namespace MobileComms_ITK
{
    public class RabbitMQ
    {
        public class Command 
        {
            public string Exchange { get; set; }
            public string RoutingKey { get; set; }

            public Type Type { get; set; }
        }

        public Dictionary<string, Type> InboundQueues { get; } = new Dictionary<string, Type>()
        {
            { "inbound.Dropoff", typeof(Dropoff_POST) },
            { "inbound.JobCancel", typeof(JobCancel_POST) },
            { "inbound.JobRequest", typeof(JobRequest_POST) },
            { "inbound.JobSegmentModify", typeof(JobSegmentModify_POST) },
            { "inbound.Pickup", typeof(Pickup_POST) },
            { "inbound.PickupDropoff", typeof(PickupDropoff_POST) },
            { "inbound.SubscriptionConfig", typeof(SubscriptionConfig_PUT) },
        };
        public Dictionary<string, Type> OutboundQueues { get; } = new Dictionary<string, Type>()
        {
            { "outbound.DataStoreValue", typeof(DataStoreValue) },
            { "outbound.datastore.{Name}", typeof(DataStoreValue) },
            { "outbound.Dropoff", typeof(Dropoff) },
            { "outbound.Job", typeof(Job) },
            { "outbound.JobCancel", typeof(JobCancel) },
            { "outbound.JobRequest", typeof(JobRequest) },
            { "outbound.JobSegment", typeof(JobSegment) },
            { "outbound.JobSegmentModify", typeof(JobSegmentModify) },
            { "outbound.Pickup", typeof(Pickup) },
            { "outbound.PickupDropoff", typeof(PickupDropoff) },
            { "outbound.Robot", typeof(Robot) },
            { "outbound.RobotFault", typeof(RobotFault) },
            { "outbound.SubscriptionConfig", typeof(SubscriptionConfig) },
        };
        public string UserName => "toolkitadmin";
        public string ConnectionString(string host, string password) => $"amqps://{UserName}:{password}@{host}/";
        public IConnection Connection { get; private set; }
        public IModel GetChannel { get; private set; }
        public IModel PutChannel { get; private set; }

        public Dictionary<string, IModel> Channels { get; } = new Dictionary<string, IModel>();
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
                ConnectionFactory factory = new ConnectionFactory { Uri = new Uri(ConnectionString(host, password)) };
                factory.Ssl.AcceptablePolicyErrors = System.Net.Security.SslPolicyErrors.RemoteCertificateNameMismatch | System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors;

                Connection = factory.CreateConnection();

                if(!Connection.IsOpen)
                {
                    Connection.Dispose();
                    Connection = null;
                    return false;
                }


                GetChannel = Connection.CreateModel();
                PutChannel = Connection.CreateModel();

                return true;
            }
            catch(Exception ex)
            {
                IsException = true;
                RabbitMQException = ex;
                return false;
            }


        }

        public bool CreateNewChannel(string name)
        {
            if(!Connection.IsOpen) return false;
            Channels.Add(name, Connection.CreateModel());

            return true;
        }

        public class Message
        {
            public ulong DeliveryTag { get; set; }
            public string Body { get; set; }
            public string Exchange { get; set; }
            public string RoutingKey { get; set; }
            public bool Redelivered { get; set; }
            public Message(ulong dt, string bd, string ex, string rk, bool rd)
            {
                DeliveryTag = dt;
                Body = bd;
                Exchange = ex;
                RoutingKey = rk;
                Redelivered = rd;
            }
        }
        public class Messages : List<Message> { }

        public Messages Get(string queue)
        {
            return Get(queue, GetChannel);
        }
        public Messages Get(string queue, string channelName)
        {
            if(!Channels.ContainsKey(channelName)) return new Messages();
            return Get(queue, Channels[channelName]);
        }
        private Messages Get(string queue, IModel channel)
        {
            Messages lst = new Messages();

            if(!Connection.IsOpen) return lst;
            if(channel == null) return lst;

            while(true)
            {
                var res = channel.BasicGet(queue, false);

                if(res == null)
                    return lst;
                else
                    lst.Add(new Message(res.DeliveryTag, Encoding.UTF8.GetString(res.Body.ToArray(), 0, res.Body.Length), res.Exchange, res.RoutingKey, res.Redelivered));
            }
        }
        public void Put(string queue, string json)
        {
            if(PutChannel == null)
                return;
            if(PutChannel.IsClosed)
                return;
            PutChannel.BasicPublish("", queue, false, null, Encoding.UTF8.GetBytes(json));

            //PutChannel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

            //PutChannel.QueueBind(queue: queue,
            //                  exchange: "",
            //                  routingKey: queue);

            //Console.WriteLine(" [*] Waiting for logs.");

            //var consumer = new EventingBasicConsumer(PutChannel);
            //consumer.Received += (model, ea) =>
            //{
            //    var body = ea.Body.ToArray();
            //    var message = Encoding.UTF8.GetString(body);
            //    Console.WriteLine(" [x] {0}", message);
            //};
            //PutChannel.BasicConsume(queue: queue,
            //                     autoAck: true,
            //                     consumer: consumer);

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();
        }
    }
}
