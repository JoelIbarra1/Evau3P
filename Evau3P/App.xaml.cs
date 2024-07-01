using Evau3P.MVVM.View;
using Microsoft.Extensions.DependencyInjection;

namespace Evau3P
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(ServiceProvider.GetService<JokesView>());
        }
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void InitializeServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
