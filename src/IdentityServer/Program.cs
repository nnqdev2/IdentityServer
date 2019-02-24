﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.IO;
using System.Linq;

namespace IdentityServerAspNetIdentity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var seed = args.Any(x => x == "/seed");
            if (seed) args = args.Except(new[] { "/seed" }).ToArray();

            var host = CreateWebHostBuilder(args).Build();

            if (seed)
            //if (true)
            {
                using (var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    SeedData.EnsureSeedData(scope.ServiceProvider);
                    return;
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            //return WebHost.CreateDefaultBuilder(args)
            //        .UseStartup<Startup>()
            //        .UseSerilog((context, configuration) =>
            //        {
            //            configuration
            //                .MinimumLevel.Debug()
            //                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //                .MinimumLevel.Override("System", LogEventLevel.Warning)
            //                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
            //                .Enrich.FromLogContext()
            //                .WriteTo.File(@"identityserver4_log.txt")
            //                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
            //        });

            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://localhost:44317;http://localhost:5000;http://deqwebdev")
                .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseSerilog((context, configuration) =>
                    {
                        configuration
                            .MinimumLevel.Debug()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                            .MinimumLevel.Override("System", LogEventLevel.Warning)
                            .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                            .Enrich.FromLogContext()
                            .WriteTo.File(@"identityserver4_log.txt")
                            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
                    });
                    }
    }
}
