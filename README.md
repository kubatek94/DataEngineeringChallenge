# DataEngineeringChallenge

To start this challenge you will need [docker](https://www.docker.com/get-docker).

To run all the required infrastructure you will need to navigate to /KafkaDataProducer and run ```docker-compose up -d```. This will spin up zookeeper, kakfa, kafka connect, sql server and a c# app to produce messages onto kafka.

The challenge is as follows.
1) Get data into sql server from kafka. (The connection string for sql server is different depending on whether you are connecting from your PC, or from within the docker network. If you are connecting from your PC the connection string is: ```localhost:1400;database=TransactionDb;user=sa;password=Y37uigwzrUA%```. If within the docker network: ```sqlserver:1433;database=TransactionDb;user=sa;password=Y37uigwzrUA%```)
