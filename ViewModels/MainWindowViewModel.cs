using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPF_Test.Infrastructure.Commands;
using WPF_Test.Models;
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

        #region bitmap
        private BitmapSource _bitmapSrc;
        public BitmapSource BitmapSrc
        {
            get => _bitmapSrc;
            set => Set(ref _bitmapSrc, value);
        }
        #endregion

        #region img
        NoizeImgGenerator _noizeImgGenerator;
        public int ImgWidth { get => _noizeImgGenerator.Width; }
        public int ImgHeight { get => _noizeImgGenerator.Height; } 
        #endregion

        #region commands

        public ICommand DrawPointCmd { get; }
        private bool Can_DrawPointCmd_Execute(object p) => true;
        private void On_DrawPointCmd_Executed(object p) => BitmapSrc = _noizeImgGenerator.GetNoizeBitmapSource();

        #endregion

        public MainWindowViewModel()
        {
            DrawPointCmd = new LambdaCommand(On_DrawPointCmd_Executed, Can_DrawPointCmd_Execute);
            _noizeImgGenerator = new NoizeImgGenerator();
        }
    }
}
