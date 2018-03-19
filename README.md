# DataEngineeringChallenge

To start this challenge you will need [docker](https://www.docker.com/get-docker).

To run all the required infrastructure you will need to navigate to /KafkaDataProducer and run ```docker-compose up -d```. This will spin up zookeeper, kakfa, kafka connect, sql server and a c# app to produce messages onto kafka.

The challenge is as follows.
1) The business want to do some reports on the data that is currently getting published to kafka. The first task is to get data into sql server from kafka. (The connection string for sql server is different depending on whether you are connecting from your PC, or from within the docker network. If you are connecting from your PC the connection string is: ```localhost:1400;database=TransactionDb;user=sa;password=Y37uigwzrUA%```. If within the docker network: ```sqlserver:1433;database=TransactionDb;user=sa;password=Y37uigwzrUA%```)

2) As the business is growing the query MerchantTransactions that is running in TransactionDb on SqlServer is taking longer and longer to run. Is there anything we can do to speed this query up. The query is in a stored produced that is [here](https://github.com/Judopay/DataEngineeringChallenge/blob/master/KafkaDataProducer/KafkaDataProducer/Migrations/20180316141500_Initial.cs#L111)

3) As part of the analytics of the business, the business wants to know the total amount processed per; day, week and month. How you implement this is up to you. 
