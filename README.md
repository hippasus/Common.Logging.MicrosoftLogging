# Microsoft.Extensions.Logging.CommonLogging

This project provides a logging provider for Microsoft Logging by using [Commong.Logging](https://github.com/net-commons/common-logging).


## How to use

* Install nuget package `Common.Logging.MicrosoftLogging`
* Add Commong Logging in the ConfigureLogging method during host creating process

```csharp
using Common.Logging.MicrosoftLogging;

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureLogging((context, logging) =>
        {
            logging.AddCommonLogging();
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```
