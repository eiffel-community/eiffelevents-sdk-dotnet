DOCKER := docker

DOCKER_COMPOSE := docker compose \
	--project-name "eiffel" \
	--project-directory "./examples/deploy" \
	--file "./examples/deploy/docker-compose.yml"

DOCKER_COMPOSE_UP         = $(DOCKER_COMPOSE) up --no-deps
DOCKER_COMPOSE_CONFIG     = $(DOCKER_COMPOSE) config
DOCKER_COMPOSE_LOGS       = $(DOCKER_COMPOSE) logs --follow
DOCKER_COMPOSE_EXEC       = $(DOCKER_COMPOSE) exec
DOCKER_COMPOSE_BUILD      = $(DOCKER_COMPOSE) build
DOCKER_COMPOSE_DOWN       = $(DOCKER_COMPOSE) down
DOCKER_COMPOSE_STOP       = $(DOCKER_COMPOSE) stop
DOCKER_COMPOSE_START      = $(DOCKER_COMPOSE) start
DOCKER_COMPOSE_RESTART    = $(DOCKER_COMPOSE) restart

### $ SERVICE_NAME =                                  { rabbitmq,subscriber-one, subscriber-two }
SERVICES := rabbitmq subscriber-one subscriber-two

### * make docker-config                                   Validates and views the Compose file
.PHONY: docker-config
docker-config:
	$(DOCKER_COMPOSE_CONFIG)

### * make docker-it-SERVICE_NAME                        Composes up a service in detached mode
.PHONY: $(SERVICES:%=docker-it-%)
$(SERVICES:%=docker-it-%): docker-it-%:
	$(DOCKER) container exec -it $* /bin/bash

### * make docker-list-services                            Lists all services in docker-compose file
.PHONY: docker-list-services
docker-list-services:
	$(DOCKER_COMPOSE_CONFIG) --services

### * make docker-logs                                     Gets logs of all services
.PHONY: docker-logs
docker-logs:
	$(DOCKER_COMPOSE_LOGS)

### * make docker-logs-SERVICE_NAME                        Gets logs of a service
.PHONY: $(SERVICES:%=docker-logs-%)
$(SERVICES:%=docker-logs-%): docker-logs-%:
	$(DOCKER_COMPOSE_LOGS) $*

### * make docker-build                                    Builds all services
.PHONY: docker-build
docker-build:
	$(DOCKER_COMPOSE_BUILD) $(SERVICES)

### * make docker-build-SERVICE_NAME                       Builds a service
.PHONY: $(SERVICES:%=docker-build-%)
$(SERVICES:%=docker-build-%): docker-build-%:
	$(DOCKER_COMPOSE_BUILD) $*

### * make docker-up                                       Composes up all services
.PHONY: docker-up
docker-up:
	$(DOCKER_COMPOSE_UP) $(SERVICES)

### * make docker-up-d                                     Composes up all services in detached mode
.PHONY: docker-up-d
docker-up-d:
	$(DOCKER_COMPOSE_UP) --detach $(SERVICES)

### * make docker-up-SERVICE_NAME                          Composes up a service
.PHONY: $(SERVICES:%=docker-up-%)
$(SERVICES:%=docker-up-%): docker-up-%:
	$(DOCKER_COMPOSE_UP) $*

### * make docker-up-d-SERVICE_NAME                        Composes up a service in detached mode
.PHONY: $(SERVICES:%=docker-up-d-%)
$(SERVICES:%=docker-up-d-%): docker-up-d-%:
	$(DOCKER_COMPOSE_UP) --detach $*

### * make docker-down                                     Stops and removes all services 
.PHONY: docker-down
docker-down:
	$(DOCKER_COMPOSE_DOWN)

### * make docker-down-v                                   Stops and removes services with volumes
.PHONY: docker-down-v
docker-down-v:
	$(DOCKER_COMPOSE_DOWN) --volumes

### * make docker-stop                                     Stops all services
.PHONY: docker-stop
docker-stop:
	$(DOCKER_COMPOSE_STOP)

### * make docker-stop-SERVICE_NAME                        Stops a service
.PHONY: $(SERVICES:%=docker-stop-%)
$(SERVICES:%=docker-stop-%): docker-stop-%:
	$(DOCKER_COMPOSE_STOP) $*

### * make docker-start                                    Starts all services
.PHONY: docker-start
docker-start:
	$(DOCKER_COMPOSE_START) $(SERVICES)

### * make docker-start-SERVICE_NAME                       Starts a service
.PHONY: $(SERVICES:%=docker-start-%)
$(SERVICES:%=docker-start-%): docker-start-%:
	$(DOCKER_COMPOSE_START) $*

### * make docker-restart                                  Restarts all services
.PHONY: docker-restart
docker-restart:
	$(DOCKER_COMPOSE_RESTART) $(SERVICES)

### * make docker-restart-SERVICE_NAME                     Restarts a service
.PHONY: $(SERVICES:%=docker-restart-%)
$(SERVICES:%=docker-restart-%): docker-restart-%:
	$(DOCKER_COMPOSE_RESTART) $*

### * make docker-bash-SERVICE_NAME                        Logs into a service bash
.PHONY: $(SERVICES:%=docker-bash-%)
$(SERVICES:%=docker-bash-%): docker-bash-%:
	$(DOCKER_COMPOSE_EXEC) $* bash