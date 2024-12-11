using Kursach;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBases.DataContext;

namespace Kursach
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Стартуем приложение с использованием DI
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetRequiredService<Form1>()); // MainForm — ваша главная форма
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            // Прямо задаём строку подключения
            var connectionString = "Server=.;Database=BD_Kurs;Integrated Security=true; TrustServerCertificate=True";

            // Регистрация DbContext
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString));

            // Регистрация форм
            services.AddTransient<Form1>();
        }
    }
}
