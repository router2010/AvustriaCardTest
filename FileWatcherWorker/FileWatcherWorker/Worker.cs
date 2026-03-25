using Microsoft.Extensions.Options;

namespace FileWatcherWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly FolderSettings _settings;
        private FileSystemWatcher _watcher;

        public Worker(ILogger<Worker> logger, IOptions<FolderSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Directory.CreateDirectory(_settings.InputFolder);
            Directory.CreateDirectory(_settings.OutputFolder);

            _logger.LogInformation($"Watching folder: {_settings.InputFolder}");

            // ✅ Process existing files
            var existingFiles = Directory.GetFiles(_settings.InputFolder);
            _logger.LogInformation($"Found {existingFiles.Length} existing files");

            foreach (var file in existingFiles)
            {
                ProcessFile(file);
            }

            // ✅ Watch for new files
            _watcher = new FileSystemWatcher(_settings.InputFolder)
            {
                EnableRaisingEvents = true,
                Filter = "*.*"
            };

            _watcher.Created += (s, e) => ProcessFile(e.FullPath);

            return Task.CompletedTask;
        }

        private void ProcessFile(string path)
        {
            Task.Run(() =>
            {
                try
                {
                    _logger.LogInformation($"Processing: {path}");

                    WaitForFile(path);

                    var processor = new FileProcess(path);
                    processor.Start(_settings.OutputFolder);

                    _logger.LogInformation($"Processed: {Path.GetFileName(path)}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error processing file {path}");
                }
            });
        }

        private void WaitForFile(string path)
        {
            while (true)
            {
                try
                {
                    using (File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        break;
                    }
                }
                catch
                {
                    Thread.Sleep(200);
                }
            }
        }
    }
}