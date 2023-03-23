
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Drawing;

string endPoint = "https://myoliinykcognservice.cognitiveservices.azure.com/";

string key = "9d7fca2694bb4aa1993d04f50cea6184";

ComputerVisionClient computerVisionClient = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
{
    Endpoint = endPoint
};

string img_path = "https://hai.stanford.edu/sites/default/files/styles/person_big/public/2020-03/billgatesheadshot.jpg?itok=6fmYlCKg";


//List<VisualFeatureTypes?>features = Enum.GetValues(typeof(VisualFeatureTypes)).OfType<VisualFeatureTypes?>().ToList(); //колекція характеристик за якими можна аналізувати зображення

List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() { VisualFeatureTypes.Tags };

ImageAnalysis imageAnalysis = await computerVisionClient.AnalyzeImageAsync(img_path,features);

//analitics photo
foreach (var item in imageAnalysis.Description.Captions)
{
    Console.WriteLine($"{item.Text} ");
    Console.WriteLine($"{item.Confidence} ");//ймовірність
    //Console.WriteLine($"{item.Rectangle.X} : {item.Rectangle.Y} ");
    //Console.WriteLine($"{item.Rectangle.W} : {item.Rectangle.H} ");
    //Console.WriteLine($"{item.Rectangle.W} : {item.Rectangle.H} ");
}

foreach (var item in imageAnalysis.Tags)
{
    Console.WriteLine($"{item.Name} ");
    Console.WriteLine($"{item.Confidence} ");//ймовірність
    Console.WriteLine($"{item.Hint} ");//підказка
    //Console.WriteLine($"{item.Rectangle.X} : {item.Rectangle.Y} ");
    //Console.WriteLine($"{item.Rectangle.W} : {item.Rectangle.H} ");
    //Console.WriteLine($"{item.Rectangle.W} : {item.Rectangle.H} ");
}

foreach (var item in imageAnalysis.Categories)
{
    Console.WriteLine($"{item.Name} ");
    Console.WriteLine($"{item.Detail} ");//ймовірність
    Console.WriteLine($"{item.Score} ");
    //Console.WriteLine($"{item.Rectangle.X} : {item.Rectangle.Y} ");
    //Console.WriteLine($"{item.Rectangle.W} : {item.Rectangle.H} ");
    //Console.WriteLine($"{item.Rectangle.W} : {item.Rectangle.H} ");
}

foreach (var item in imageAnalysis.Tags)
{
    Console.WriteLine($"{item.Name} ");
    Console.WriteLine($"{item.Confidence} ");//ймовірність
    Console.WriteLine($"{item.Hint} ");//підказка
    //Console.WriteLine($"{item.Rectangle.X} : {item.Rectangle.Y} ");
    //Console.WriteLine($"{item.Rectangle.W} : {item.Rectangle.H} ");
    //Console.WriteLine($"{item.Rectangle.W} : {item.Rectangle.H} ");
}
foreach (var item in imageAnalysis.Objects)
{
    Console.WriteLine($"{item.ObjectProperty} ");
    Console.WriteLine($"{item.Confidence} ");//ймовірність

    Console.WriteLine($"{item.Rectangle.X} : {item.Rectangle.Y} ");
    Console.WriteLine($"W:{item.Rectangle.W} - H:{item.Rectangle.H} ");
   
}
foreach (var item in imageAnalysis.Brands)
{
    Console.WriteLine($"{item.Name} ");
    Console.WriteLine($"{item.Confidence} ");//ймовірність

}
Console.WriteLine("AccentColor: "+ imageAnalysis.Color.AccentColor);
Console.WriteLine("AdultScore: " + imageAnalysis.Adult.AdultScore);
Console.WriteLine("IsAdultContent: " + imageAnalysis.Adult.IsAdultContent);
Console.WriteLine("IsRacyContent: " + imageAnalysis.Adult.IsRacyContent);
Console.WriteLine("RacyScore: " + imageAnalysis.Adult.RacyScore);

Console.WriteLine("Foregraund: "+ imageAnalysis.Color.DominantColorForeground);
Console.WriteLine("Backgraund: "+ imageAnalysis.Color.DominantColorBackground);
Console.WriteLine("Dominant: " + string .Join(",",imageAnalysis.Color.DominantColors));
Console.WriteLine("IsBWImg: " + imageAnalysis.Color.IsBWImg);



Console.ReadLine();