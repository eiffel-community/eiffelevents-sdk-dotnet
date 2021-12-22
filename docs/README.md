# Docs

Documentation for EiffelEvents.NET SDK consists of two parts

## Design Specifications

For the SDK architecture and design specifications please refer to [Articles](docfx_project/articles).

### [Introduction](docfx_project/articles/index.md)

### [Architecture](docfx_project/articles/architecture.md)

#### 	[EiffelEvents](docfx_project/articles/architecture-eiffelevents.md)

#### 	[RabbitMQ Communication Design](docfx_project/articles/architecture-rabbitmq-client.md)

#### 	[Implement Events Checklist](docfx_project/articles/implement-event.md)

## API Documentation 

For detailed API description please build and publish documentation website using DocFX, using either [Docfx Helper](DocFX-helper.md) or the following Make commands: 

*Note: use these commands under the repo root directory.*

- `make docfx`:  Reads source, generates and builds the HTML site.
- `make docfx-serve`:   Publish the documentation (the generated HTML) in folder "_site" to localhost.

