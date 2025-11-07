using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace ASCII_Art_Generator
{
    internal sealed class Generator
    {
        public string GenerateAsciiArtFromImage(Stream inputStream)
        {
            var asciiChars = "@%#*+=-:,. ";
            // var asciiChars = "\"$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,\"^`'. \"";

            using var image = new Bitmap(inputStream);

            int outputWidth = image.Width / 3; // Tu można zmienić szerokość
            int widthStep = Math.Max(1, image.Width / outputWidth);
            int outputHeight = image.Height / 3; // Tu można zmienić wysokość
            int heightStep = Math.Max(1, image.Height / outputHeight);

            StringBuilder asciiBuilder = new(outputWidth * outputHeight);
            for (var h = 0; h < image.Height; h += heightStep)
            {
                for (var w = 0; w < image.Width; w += widthStep)
                {
                    var pixelColor = image.GetPixel(w, h);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    var asciiChar = asciiChars[grayValue * (asciiChars.Length - 1) / 255];
                    asciiBuilder.Append(asciiChar);
                    asciiBuilder.Append(asciiChar);
                    // Dodaję to dwa razy z takiego powodu, żeby obraz w konsoli wyglądał bardziej naturalnie
                }
                asciiBuilder.AppendLine();
            }

            return asciiBuilder.ToString();
        }
    }
}
