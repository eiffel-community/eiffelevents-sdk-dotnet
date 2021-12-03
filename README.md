# Eiffel.NET #

Eiffel .NET library provides a .NET implementation for Eiffel protocol is considered as an Event Publishing service. It provides Assisted publishing, which acts as an intermediate between the event author (publisher) and the Message Broker (RabbitMQ for instance).

Eiffel.NET features include:

- Implement Eiffel events vocabularies as described in [eiffel-edition-paris](https://github.com/eiffel-community/eiffel/tree/edition-paris) 
- Validate events' schema regarding target event’s version.
- Provide  APIs for library users to publish, subscribe, and unsubscribe for strongly-typed Eiffel events to RabbitMQ.

[TOC]

## Services

- **RabbitMQ**: service exists in `deploy/services/rabbitmq` directory.

## Technologies

- .NET 6
- C# (9)
- Docker  (19.03)
- Docker Compose  (2.0.0)
- Makefile

### Dependencies

- **RabbitMQ.Client 6.2.2**
- **FluentResult 2.5.0**: An external library for  [Result](https://github.com/altmann/FluentResults) object implementation, NuGet [link](https://www.nuget.org/packages/FluentResults/).
- **Newtonsoft.Json 13.0.1**
-  **[DocFX](https://dotnet.github.io/docfx/index.html)** documentation generation tool.



## Requirements ##

### For getting the application up and running ###

- Makefile (<https://www.gnu.org/software/make/>).
- Docker ([Installation](https://docs.docker.com/engine/installation/)).
- Docker Compose ([Installation](https://docs.docker.com/compose/install/)).

### For development ###

- .NET 6 ([Installation](https://dotnet.microsoft.com/download/dotnet/6.0)).
- For installing needed .NET tools: `make dotnet-tool-restore`.

## Quick Start ##

1. Clone the repository.
1. Switch to the development branch.

## Configuration ##

### RabbitMQ Configuration ###

TBW

#### Docker ####

The following files are used to configure project services:

- [deploy/docker-compose.yml](deploy/docker-compose.yml): Used to configure services.
- [deploy/.env](deploy/.env): Contains the needed environment variables to configure all services that is defined in the `docker-compose.yml`.

#### Docker Compose Services

- **rabbitmq**: RabbitMQ service to handle messages queues.
- **subscriber-one**: a console app referencing Eiffel.NET library that subscribes to some events and logs them when received.
- **subscriber-two**: a console app referencing Eiffel.NET library that subscribes to some events and logs them when received.

## Docs

Docs directory resides under repo root, tt structured as following:

**docfx_project:** The Docs generation code reside in this folder.

**docfx_project/_site:** The generated Docs pages will be reside in this folder.

### Tools to generate docs

[DocFX](https://dotnet.github.io/docfx/index.html) documentation generation tool used. 

#### Installation

##### Under Windows #####

###### Install from NuGet ######

* Install [Nuget.exe](https://dist.nuget.org/index.html)
* Create a folder, e.g. *C:\Tools\docfx*, under the folder, `nuget install docfx.console`
* Open command line:

```batch
set PATH=%PATH%;C:\Tools\docfx\docfx.console\tools
```

###### Install from choco ######

* Install [chocolatey](https://chocolatey.org/install), a Windows package manager.
* Open command line:

```batch
choco install docfx
```

###### Cross platform ######

* Install [Mono](http://www.mono-project.com/download/#download-lin)
* Install [Nuget.exe](https://docs.microsoft.com/en-us/nuget/reference/nuget-exe-cli-reference)
* Install DocFX version 2.51.0 (As later versions have [issue with mono](https://github.com/dotnet/docfx/issues/5785))

```sh
mono /path/to/nuget.exe install docfx.console -version 2.51.0 -o /path/to/install/docfx.console
```

#### Generation Commands

- `make docfx`:  Reads source, generates and builds the HTML site.
- `make docfx-serve`:   Publish the documentation (the generated HTML) in folder "_site" to localhost.
- For more details please check [Docfx Readme](docs/README.md)



## Make Commands ##

Makefiles are available on `.scripts` directory and the main Make file on the root directory,  to help running common CLI commands.
The following list provides the most used make commands:

- `make help`: Shows a list of all make commands with their description.
- `make docker-build`: Builds all services as docker containers.
- `make docker-up`: Starts all services.
- `make docker-up-[service name]`: Start a specific service in docker-compose file such as: `make docker-up-rabbitmq`, `make docker-up-subscriber-one`, or `make docker-up-subscriber-two`
- `make docker-down`: Stops and removes all services

