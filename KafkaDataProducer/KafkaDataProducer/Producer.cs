using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdGen;
using Judo.Kafka;
using KafkaDataProducer.Models;

namespace KafkaDataProducer
{
    class Producer
    {
        private readonly string SchemaRegistryConnection = "http://schemaregistry:8081";
        private readonly string Topic = "Transactions";
        private readonly IdGenerator _idGenerator;

        public Producer()
        {
            _idGenerator = new IdGenerator(0);
        }

        public async Task StartProducing(int messagesToProduce)
        {

            var kafkaBootstrapServer = "kafka:9092";
            var topicConfiguration = new Dictionary<string, object>
            {
                { "request.required.acks", 1 },
                { "request.timeout.ms", 2000 },
                { "message.timeout.ms", 2000 },
            };

            // Create the producer configuration
            var configuration = new Dictionary<string, object>
            {
                { "api.version.request", true },
                { "bootstrap.servers", kafkaBootstrapServer },
                { "default.topic.config", topicConfiguration }
            };

            // Create a new topic producer
            var kafkaProducer = KafkaClient.Connect(SchemaRegistryConnection, configuration).GetTopicProducer(Topic, true);

            try
            {
                var transaction = CreateTransctionModel();
                var message = await kafkaProducer.ProduceAsync(transaction.CustomerId, transaction);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Something went wrong aborting");
                return;
            }

            // create 10 tasks to produce messages
            var tasks = Enumerable.Range(0, 10)
                .Select(x =>
                {
                    var i1 = messagesToProduce / 10;
                    var dave = new Task[i1];
                    for (var i = 0; i < i1; i++)
                    {
                        var transaction = CreateTransctionModel();
                        dave[i] = kafkaProducer.ProduceAsync(transaction.CustomerId, transaction);
                    }

                    return Task.WhenAll(dave);
                });

            //wait for everything to produce
            await Task.WhenAll(tasks);
        }

        private int[] ConsumerIds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int[] MerchantIds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        

        private Transaction CreateTransctionModel()
        {
            var random = new Random();
            var merchantIndex = random.Next(10);
            var consumerIndex = random.Next(10);
            decimal amount = random.Next(500000) / (decimal)100m;

            var id = _idGenerator.CreateId();

            var transaction = new Transaction
            {
                Id = id,
                Amount = amount,
                CardNumber = "4976000000003436",
                CustomerId = ConsumerIds[consumerIndex],
                MerchantId = MerchantIds[merchantIndex],
                CreatedDate = DateTime.UtcNow
            };
            return transaction;
        }
    }
}
