DOCFX := docfx

### * make docfx                        		            Reads source, generates and builds the HTML site
.PHONY: docfx
docfx:
	$(DOCFX) docs/docfx_project/docfx.json

### * make docfx-metadata                                  Reads source code metadata and generates intermediate metadata YAML files
.PHONY: docfx-metadata
docfx-metadata:
	$(DOCFX) metadata docs/docfx_project/docfx.json

### * make docfx-build                                     Builds the HTML site from generated metadata
.PHONY: docfx-build
docfx-build:
	$(DOCFX) build docs/docfx_project/docfx.json

### * make docfx-serve                                     Publish the documentation (the generated HTML) in folder "_site" to localhost
.PHONY: docfx-serve
docfx-serve:
	$(DOCFX) serve docs/docfx_project/_site --port 8888
