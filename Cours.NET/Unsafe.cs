using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Security.Cryptography;

class UnsafeClass
{
    public static void Main()
    {
        var image = new Bitmap(1000, 1000, PixelFormat.Format32bppArgb);

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
            {
                Color pixel = image.GetPixel(x, y);

                byte pixelA = pixel.A;
                byte pixelR = pixel.R;
                byte pixelG = pixel.G;
                byte pixelB = pixel.B;
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Standard time: {stopwatch.Elapsed}");
        stopwatch.Restart();
        unsafe
        {
            var imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
            int bytesPerPixel = 3;
            byte* scan0 = (byte*)imageData.Scan0.ToPointer();
            int stride = imageData.Stride;
            for (int y = 0; y < imageData.Height; y++)
            {
                byte* row = scan0 + (y * stride);

                for (int x = 0; x < imageData.Width; x++)
                {
                    // Cause by little indian
                    int bIndex = x * bytesPerPixel;
                    int gIndex = bIndex + 1;
                    int rIndex = bIndex + 2;
                    int aIndex = bIndex + 3;

                    byte pixelA = row[aIndex];
                    byte pixelR = row[rIndex];
                    byte pixelG = row[gIndex];
                    byte pixelB = row[bIndex];
                }
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"unsafe time: {stopwatch.Elapsed}");

        Console.Out.WriteLine(String.Join(" ", UnsafeMethod(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })));
    }

    public static unsafe byte[] UnsafeMethod(byte[] source)
    {
        byte[] newArr = new byte[5];
        fixed (byte* ptr = source, newPtr = newArr)
        {
            for (int i = 0; i < 5; i++)
            {
                newPtr[i] = ptr[i];
            }
        }
        return newArr;
    }
}
