# JupyterSharp

Access Jupyter API via Visual C#.

## Description

.NET package to access Jupyter Notebook Server API via Visual C#.

## Requirement

- .NET Standard 2.0

## Usage

### Installation

You can start using this package by two ways.

- Install with [NuGet](https://www.nuget.org/packages/JupyterSharp/) (Recommended)
- Clone [GitHub](https://github.com/step63r/JupyterSharp) repository and build by yourself

### Quick Start

This is the sample code for getting contents of root directory.

```
using JupyterSharp;
using JupyterSharp.Common;

namespace JupyterSharp.Sample
{
    public class Sample
    {
        private Api MyApi;

        public Sample()
        {
            // Set your Jupyter Notebook access token, IP address and port
            // Default IP address is localhost and port is 8888
            MyApi = new Api("JUPYTER TOKEN", "localhost", "8888");
        }

        public void GetContentsRootDirectory()
        {
            // Get contents of root directory
            var getRequest = MyApi.GetContents();
            var getResponse = JsonConverter.ToObject<Common.Contents>(getRequest.Content);
            // do something with getResponse
            // ...
        }
    }
}
```

### API Documentation

All wrapper API in this package are designed with [Jupyter Notebook API](http://petstore.swagger.io/?url=https://raw.githubusercontent.com/jupyter/notebook/master/notebook/services/api/api.yaml#/).

- Contents
- Sessions
- Kernels
- Kernelspecs
- Config
- Terminals
- Status
- ApiSpec

### Unit Test

This repository also includes a test project.

To run the tests, you have to do some preparations in advance as below.

- Jupyter Notebook is running at ``http://localhost:8888``
- Your Jupyter token is set to configuration key ``JupyterToken`` of JupyterSharp.Tests project

## Contribution

1. Fork this repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create new Pull Request

## Licence

MIT License

## Author

[minato](https://blog.minatoproject.com/)
