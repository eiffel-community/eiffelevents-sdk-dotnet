# Examples Projects and Docker services

## Requirements for getting the application up and running ##

- Makefile (<https://www.gnu.org/software/make/>).
- Docker ([Installation](https://docs.docker.com/engine/installation/)).
- Docker Compose ([Installation](https://docs.docker.com/compose/install/)).

## Examples Projects

- [EiffelClient.BasicPublisher](EiffelClient.BasicPublisher): A basic publisher example with an Eiffel event.
- [EiffelClient.PublisherOne](EiffelClient.PublisherOne): example project to publish Eiffel events refined to easily try different events.
- [EiffelClient.SubscriberOne](EiffelClient.SubscriberOne): example project to subscribe for Eiffel events.
- [EiffelClient.SubscriberTwo](EiffelClient.SubscriberTwo): another example project to subscribe for Eiffel events, to try scenarios such as:
  - When there are different subscribers for the same event.
  - When the Same subscriber has multi instances of a service that runs simultaneously where the message will be delivered to only one instance.

## Docker ##

The following files are used to configure project services:

- [deploy/docker-compose.yml](deploy/docker-compose.yml): Used to configure services.
- [deploy/.env](deploy/.env): Contains the needed environment variables to configure all services that are defined in the `docker-compose.yml`.

## Docker Compose Services

- **rabbitmq**: RabbitMQ service to handle messages queues, it exists in `deploy/services/rabbitmq` directory.
- **subscriber-one**: a console app referencing the EiffelEvents.NET project that subscribes to some events and logs them when received.
- **subscriber-two**: a console app referencing the EiffelEvents.NET project that subscribes to some events and logs them when received.

## Running Samples

For demo purposes, we provided sample projects and the Docker services section for fast up and running.  

1. Clone the repo.
1. Check the Requirements section.
1. Under the repo root directory open a terminal then run the command  `make docker-up-rabbitmq` to up a RabbitMQ container with
   1. URL: http://localhost:15672/
   1. Username: admin
   1. Password: admin
1. Open another terminal then change directory to `examples/EiffelClient.EiffelClient.SubscriberOne` then run the command `dotnet run` to run the **subscriber-one**.
1. Open another terminal then change directory to `examples/EiffelClient.EiffelClient.SubscriberTwo` then run the command `dotnet run` to run the **subscriber-two**.
1. Open another terminal then change directory to `examples/EiffelClient.PublisherOne` then run the command `dotnet run` to run the publisher.
1. Note: all publish and subscribe events should be the same.

## Make Commands ##

Makefiles are available on the `.scripts` directory and the main Make file on the root directory,  to help run common CLI commands.
The following list provides the most used make commands:

- `make help`: Shows a list of all make commands with their description.
- `make docker-build`: Builds all services as docker containers.
- `make docker-up`: Starts all services.
- `make docker-up-[service name]`: Start a specific service in docker-compose file such as: `make docker-up-rabbitmq`, `make docker-up-subscriber-one`, or `make docker-up-subscriber-two`
- `make docker-down`: Stops and removes all services.
- `make docker-down-v`: Stops and removes all services and volumes.