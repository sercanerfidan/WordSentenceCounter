using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordSentenceCounter.Services;

namespace WordSentenceCounter
{
    static class Program
    {
        public static IServiceProvider _serviceProvider;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log.txt").CreateLogger();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
            var mainService = _serviceProvider.GetService<WordCounterService>();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(_serviceProvider.GetRequiredService<IWordCounterService>()));
        }


        private static void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IWordCounterService>(provider => new WordCounterService(provider.GetRequiredService<ITextHelperService>()));
            services.AddSingleton<ITextHelperService>(provider => new TextHelperService());
        }
    }
}
