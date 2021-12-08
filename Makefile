### * make help                                            Prints this help
.PHONY: help
help:
	@sed -n 's/^###//p' Makefile
	@sed -n 's/^###//p' scripts/docker.mk
	@sed -n 's/^###//p' scripts/docfx.mk



include ./examples/deploy/.env
-include ./examples/deploy/local.env
export

include ./scripts/docker.mk
include ./scripts/docfx.mk



### * make clean-run                                       Clean volume and Runs all services
.PHONY: clean-run
clean-run: down_volumes docker-down-v docker-build docker-up

### * make run                                             Runs all services
.PHONY: run
run: init_volumes docker-down-v docker-build docker-up

### * make run-d                                           Runs all services in detached mode
.PHONY: run-d
run-d: down_volumes init_volumes docker-down-v docker-build docker-up-d

### * make clean                                           Cleans all artifacts in the repository
.PHONY: clean
clean: dotnet-clean
