using ASCII_Art_Generator;

string imagePath = @"Your Path Here";

using var inputStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
var generator = new Generator();

string asciiArt = generator.GenerateAsciiArtFromImage(inputStream);
Console.WriteLine(asciiArt);