using FileWatcherWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<FolderSettings>(
            context.Configuration.GetSection("FolderSettings"));

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
