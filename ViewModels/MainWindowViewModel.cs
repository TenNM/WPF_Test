using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Test.Infrastructure.Commands;
using WPF_Test.ViewModels.Base;

namespace WPF_Test.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region title

        private string _title = "Window title";

        /// <summary>Window title</summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);//SetProperty
        }
        #endregion

        #region commands
        
        //public ICommand CloseAppCmd { get; }
        //private bool CanCloseAppCmdExecute(object p) => true;
        //private void OnCloseAppCmdExecuted(object p) => Application.Current.Shutdown();

        #endregion

        public MainWindowViewModel()
        {
            //CloseAppCmd = new LambdaCommand(OnCloseAppCmdExecuted, CanCloseAppCmdExecute);
        }
    }
}
