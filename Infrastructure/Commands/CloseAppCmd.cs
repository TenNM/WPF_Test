using System.Windows;
using WPF_Test.Infrastructure.Commands.Base;

namespace WPF_Test.Infrastructure.Commands
{
    internal class CloseAppCmd : Command
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter) => Application.Current.Shutdown();
    }
}
