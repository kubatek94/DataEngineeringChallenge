using System;
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
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine("Starting to produce messages");
            var producer = new Producer();
            while (true)
            {
                producer.StartProducing(100).Wait();
                Console.WriteLine("Finished procducing. Press q to quit or any key to produce again");
                var readLine = Console.ReadLine();
                if ("q".Equals(readLine))
                {
                    break;
                }
            }
            
            transactionDbContext.Dispose();
        }
    }
}
