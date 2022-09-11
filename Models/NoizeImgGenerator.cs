using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Test.Models
{
    internal class NoizeImgGenerator
    {
        PixelFormat _pf;
        
        public int Width{ get; set; }
        public int Height{ get; set; }

        int _rawStride;
        byte[] _rawImage;

        Random r;

        internal NoizeImgGenerator()
        {
            _pf = PixelFormats.Rgb24;
            Width = 300;
            Height = 300;
            _rawStride = (Width * _pf.BitsPerPixel + 7) / 8;
            _rawImage = new byte[_rawStride * Height];
            r = new Random();
        }

        internal BitmapSource GetNoizeBitmapSource()
        {
            r.NextBytes(_rawImage);

            return BitmapSource.Create(Width, Height,
            96, 96, _pf, null,
            _rawImage, _rawStride);
        }
    }
}
