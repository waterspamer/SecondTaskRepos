using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the CumZone !");
            Console.WriteLine("Enter reference file name :");
            var fileName = Console.ReadLine();
            Console.WriteLine("Enter output file name :");
            var outputFileName = Console.ReadLine();
            var res = GetGreyScaleFromRGB(GetImageFromFile(fileName));
            WriteDataToFile(res, outputFileName);
            Console.WriteLine("Success !");
        }

        static Bitmap GetGreyScaleFromRGB (Bitmap rgbBitmap)
        {
            var result = new Bitmap(rgbBitmap);
            var counter = 0f;
            var num = result.Height * result.Width;
            for (int i = 0; i < rgbBitmap.Width; ++i)
            {
                for (int j = 0; j < rgbBitmap.Height; ++j)
                {
                    result.SetPixel(i, j, GetGreyscale(rgbBitmap.GetPixel(i, j)));
                    counter++;
                    Console.WriteLine($"Progress : {counter/(float)num * 100}%");
                }
            }
            return result;
        }

        static Color GetGreyscale (Color color)
        {
            var median = (int)((color.R + color.G + color.B) / 3f);
            return Color.FromArgb(1, median, median, (median));
        }

        static Bitmap GetImageFromFile (string filename) =>
            (Bitmap)Image.FromFile(filename);


        static void WriteDataToFile (Bitmap data, string filename)=> 
            data.Save(filename, ImageFormat.Bmp);
    }
}
