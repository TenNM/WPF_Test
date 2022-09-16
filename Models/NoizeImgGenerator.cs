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
        internal BitmapSource GetBitmapSourceWithNewPixel()
        {
            SetPixel( r.Next(Width), r.Next(Height), Color.FromRgb(255, 255, 255) );

            return BitmapSource.Create(Width, Height,
            96, 96, _pf, null,
            _rawImage, _rawStride);
        }
        internal void SetPixel(int x, int y, Color c)
        {
            if (x < 0) throw new ArgumentOutOfRangeException("x < 0");
            if (x >= Width) throw new ArgumentOutOfRangeException("x > Width");
            if (y < 0) throw new ArgumentOutOfRangeException("y < 0");
            if (y >= Height) throw new ArgumentOutOfRangeException("y > Height");
            if(_pf.BitsPerPixel != 24) throw new ArgumentOutOfRangeException("can't convert color");

            int index = (x + (y * Width)) * 3;//3 byte per pixel
            _rawImage[index] = c.R;
            _rawImage[index+1] = c.G;
            _rawImage[index+2] = c.B;
        }
    }
}
