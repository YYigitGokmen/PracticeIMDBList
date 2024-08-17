
using PracticeImdbList;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

public class Program
{
    public static void Main(string[] args)
    {

        List<Movie> Movies = new List<Movie>();


        while (true)
        {
            Console.Write("Lüften film adı giriniz (Listeyi yazdırmak veya çıkmak için çıkış yazınız) : ");
            string movieName = Console.ReadLine();


            if (movieName.ToLower() == "çıkış")
            {
                break;
            }

            Console.Write("Lüften IMDB puanını giriniz :");
            double ımdbScore;

            while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out ımdbScore) || ımdbScore < 0 || ımdbScore > 10)
            {
                Console.WriteLine("Lütfen 10 ve 0 arasında bir puan giriniz!");
            }


            Movie Movie = new Movie { name = movieName, ımdbScore = ımdbScore };
            Movies.Add(Movie);

            Console.WriteLine("Film Eklendi! \n");

        }


        Console.WriteLine("Girdiğiniz filmlerin listesi: \n");

        foreach (Movie movie in Movies)
        {
            Console.WriteLine($"Film adı: {movie.name}, IMDB Puanı: {movie.ımdbScore}");
        }


        Console.WriteLine("IMDB Puanı 4 ve 9 arasında olan bütün filmler : \n");

        var filteredMovies = Movies.Where(m => m.ımdbScore >= 4 && m.ımdbScore <= 9).ToList();

        foreach (Movie movie in filteredMovies)
        {
            Console.WriteLine($"Film adı : {movie.name}, Imdb puanı : {movie.ımdbScore}");
        }


        Console.WriteLine("İsmi A harfi ile başlayan filmler : \n");

        var moviesStartWithA = Movies.Where(Movie => Movie.name.StartsWith("A")).ToList();

        foreach (Movie movie in moviesStartWithA)
        {
            Console.WriteLine($"{movie.name}, IMDB puanı: {movie.ımdbScore}");

        }

    }

}











