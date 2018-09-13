# Introduction
Testing HttpClientFactory and HttpClient.Polly on an app with dotnet core 2.1

# Getting Started

There are 2 scenarios in this repository:

- ***Scenario 1***:
  - Stand-alone multi-layer app 

- ***Scenario 2***:
  - Microservices environment with a library that contains all the proxies for communicating with the different applications.
  - All the apps are using the proxy libraries when they want to communicate with another app.


# Dependencies

- Microsoft.Extensions.Configuration.Abstractions
- Microsoft.Extensions.Logging.Abstractions
- Newtonsoft.json
- Microsoft.Extensions.Http.Polly
- Microsoft.Extensions.App
