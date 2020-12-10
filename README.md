# Microsoft.Extensions.Logging.CommonLogging

This project provides a logging provider for Microsoft Logging by using [Commong.Logging](https://github.com/net-commons/common-logging).


## How to use

* Install nuget package `Microsoft.Extensions.Logging.CommonLogging`
* Add Commong Logging in the ConfigureLogging method during host creating process

```csharp
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
