using System;
using System.Threading;
using KafkaDataProducer.Repository;
using Microsoft.EntityFrameworkCore;

namespace KafkaDataProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactionDbContext = new TransactionDbContext();
            try
            {
                transactionDbContext.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine("Migrations went wrong");
                Console.WriteLine(e);
            }

            try
            {
                Console.WriteLine("Starting to produce messages");
                var producer = new Producer();
                while (true)
                {
                    producer.StartProducing(100000).Wait();
                    Console.WriteLine("Finished procducing. Press q to quit or any key to produce again");
                    var readLine = Console.ReadLine();
                    if ("q".Equals(readLine))
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Producing went wrong");
                Console.WriteLine(e);
            }

            Console.ReadLine();
            Thread.Sleep(1000000);
            transactionDbContext.Dispose();
        }
    }
}
