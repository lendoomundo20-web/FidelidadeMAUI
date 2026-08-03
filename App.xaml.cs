using Microsoft.Extensions.DependencyInjection;

namespace Fidelidade.App
{
    public partial class App : Application
    {
        public AppShell()
        {
            InitializeComponent();
        }
        ()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}