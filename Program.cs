using ASCII_Art_Generator;

string imagePath = @"C:\Users\Tymek\Desktop\screenshots\SlimeRancher-2021-09-19-10-59-35-39.png";

using var inputStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
var generator = new Generator();

string asciiArt = generator.GenerateAsciiArtFromImage(inputStream);
Console.WriteLine(asciiArt);