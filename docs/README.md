# Docs #

This folder contains any documentation related files (such as `docfx` project that generates docs from docstrings).

DocFX allow to add custom markdown files called Conceptual files along side with generated classes documentation from Docstring, called Metadata models.

Note:

1. There are several conceptual files under `articles`.
2. `toc.yml` under root folder. It renders as the navbar of the website.
3. `docfx.json` under root folder. It is the configuration file that `docfx` depends upon.

[Installation](#Installation)

[Structure](#structure)

[Configurations](#configuration)

[Commands](#commands)

[References](#References)

## Installation ##

### Under Windows ###

#### Install from Nuget ####

* Install [Nuget.exe](https://dist.nuget.org/index.html)
* Create a folder, e.g. *C:\Tools\docfx*, under the folder, `nuget install docfx.console`
* Open command line:

```batch
set PATH=%PATH%;C:\Tools\docfx\docfx.console\tools
```

#### Install from choco ####

* Install [chocolatey](https://chocolatey.org/install), a Windows package manager.
* Open command line:

```batch
choco install docfx
```

#### **Run Commands** ####

Run (Generate metadata, build site, and publish to specific port):

Open command line: under docs folder then write

```batch
docfx docfx_project\docfx.json --serve -p 8888
```

### Cross platform ###

* Install [Mono](http://www.mono-project.com/download/#download-lin)
* Install [Nuget.exe](https://docs.microsoft.com/en-us/nuget/reference/nuget-exe-cli-reference)
* Install DocFX version 2.51.0 (As later versions have [issue with mono](https://github.com/dotnet/docfx/issues/5785))

```sh
mono /path/to/nuget.exe install docfx.console -version 2.51.0 -o /path/to/install/docfx.console
```

#### **Run Commands** ####

Run (Generate metadata, build site, and publish to specific port):

Open command line: under docs folder then write

```sh
mono /path/to/docfx.console.2.51.0/tools/docfx.exe docfx_project/docfx.json --serve -p 8888
```

## **Structure** ##

**docfx_project:** The Docs generation code reside in this folder.

**_site:** The generated Docs pages will be reside in this folder.

## Configuration ##

The configuration file for Docs generation **docfx.json** (which located in **docfx_project** folder), contains values:

> Since docfx file is a JSON file, I will add a  "_comment" attribute for clarification such as 
>
> "_comment": "destination for metadata files"

The file consists of:

- Metadata
- Build

```json
{
  "metadata": [],
  "build": {}
}
```

**Metadata**

- The source code projects path to document.
- The ignored folders or files from documentation.

```json
{
  "metadata": [
    {
      "src": [
        {
          "_comment": "Specify to include all CS files under projects, add folders under the src attribute",
          "files": [ "/**/**.csproj" ],  
         
          "_comment": "the src path which all projects reside",
          "src": "../../src",
         
          "_comment": "Exclude all bin and obj folders from generating metadata",
          "exclude": [ "**/bin/**", "**/obj/**" ]
        }
      ],
      "_comment": "destination folder for metadata files will be api folder under docfx_project ",
      "dest": "api"
    }
    ]  
  }
```

**Build**

It contains the information to build HTML web site from the metadata generated and the conceptual articles.

- The **content** source of generated metadata.
- The destination to generated documentation (**_site** in our case).
- The ignored folders or files from documentation.

```json
{
  "build": {
    "content": [
      {
        "_comment": "Specify metadata files to include in HTML generation, all metada files are YAML files",
        "files": ["api/**.yml", "api/index.md"]
      },
      {
        "_comment": "Specify conceptual articles path and table of content file, which are YAML files",
        "files": ["articles/**.md","articles/**/toc.yml", "toc.yml","*.md"]
      }
    ],
    "_comment": "Specify resources such as images or logo",
    "resource": [
      {
        "files": ["images/**","articles/images/**"]
      }
    ],
    "_comment": "Specify destination folder hold the generated HTML site.",
    "dest": "../_site"
  }
}
```

## Commands ##

> All commands will be run under **docs** folder.

**Initiation**

Initiate docfx_project folder with default configuration file **docfx_project\docfx.json**.

```batch
docfx init -q
```

If `-q` not specified you me need to answer interactive configuration questions.

**Metadata**

Read source code metadata (docstrings and classes definition) and generate intermediate metadata  YAML files in specified **dest** property in **metadata** sub-command in **docfx_project\docfx.json** configuration file.

```batch
docfx metadata docfx_project\docfx.json
```

**Build**

Build the HTML site from generated metadata as specified in specified **dest** property in **Build** sub-command in **docfx_project\docfx.json** configuration file.

```batch
docfx build docfx_project\docfx.json
```

**Metadata & Build**

Both commands will handled sequentially as **docfx** assume them a subcommands

```batch
docfx docfx_project\docfx.json
```



**Publish The Site**

Publish the documentation (the generated HTML) in folder **_site** to localhost in specified port `-p`

```batch
docfx serve _site -p 8888
```

**Templates**

**List Templates**

```batch
docfx template list
```

**Export Template**

Export site template (for CSS and other formats): this exports **default** template to a new folder **_exported_templates** under current folder.

```batch
docfx template export default
```

**Help**

```batch
docfx --help
```


## References ##

- <https://dotnet.github.io/docfx/index.html>
- <https://www.codeproject.com/Articles/5259812/Use-DocFx-to-generate-a-documentation-web-site-and>
- <https://github.com/docascode/docfx-seed>
- <https://docs.microsoft.com/en-us/contribute/how-to-write-docs-auth-pack>
- <https://docs.microsoft.com/en-us/contribute/dotnet/dotnet-style-guide>
- <https://dev.to/hardkoded/creating-a-site-for-your-project-using-docfx-4n4g>
- <https://www.youtube.com/watch?v=ftnVllssoI8>