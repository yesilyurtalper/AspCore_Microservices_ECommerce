using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace ECommerce.ItemService.API.Extentions;

public static class SerilogRegistration
{
    public static IHostBuilder AddCustomSerilog(this IHostBuilder hostBuilder) 
    {
        hostBuilder.UseSerilog((ctx, lc) => { lc
            .WriteTo.Console()
            .WriteTo.Elasticsearch(
                new ElasticsearchSinkOptions(node: new Uri(Environment.GetEnvironmentVariable("ELK_URL")))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = $"ecommerce-logs-{DateTime.Now:yyyy-MM-dd}",
                    ModifyConnectionSettings = x => x.BasicAuthentication(
                        Environment.GetEnvironmentVariable("ELK_USER"),
                        Environment.GetEnvironmentVariable("ELK_PASS"))
                    .ServerCertificateValidationCallback((o,cer,arg3,arg4) => { return true; })
                }
            )
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithClientIp()
            .Enrich.WithProperty("AppName", "ECommerce_ItemAPI")
            .Enrich.WithCorrelationIdHeader(headerKey: "x-correlation-id")
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning);
            //.ReadFrom.Configuration(ctx.Configuration);

            var logLevel = Environment.GetEnvironmentVariable("LOG_LEVEL");
            if (logLevel == "debug")
                lc.MinimumLevel.Debug();
            else if (logLevel == "warning")
                lc.MinimumLevel.Warning();
            else if (logLevel == "error")
                lc.MinimumLevel.Error();
            else if (logLevel == "fatal")
                lc.MinimumLevel.Fatal();
            else
                lc.MinimumLevel.Information();
        }); 

        return hostBuilder;
    }
}
