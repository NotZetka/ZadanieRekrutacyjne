namespace Biblioteka
{
    class Program
    {
        static void Main(string[] args)
        {
            var biblioteka = new Biblioteka();

            biblioteka.AddBook("Pan Tadeusz", "Adam Mickiewicz", 1834, "1234567890123");
            biblioteka.AddBook("Lalka", "Boleslaw Prus", 1890, "1234567890124");
            biblioteka.AddBook("Quo Vadis", "Henryk Sienkiewicz", 1896, "1234567890125");
            biblioteka.AddBook("Ferdydurke", "Witold Gombrowicz", 1937, "1234567890126");
            biblioteka.AddBook("Kamienie na szaniec", "Aleksander Kaminski", 1943, "1234567890127");

            biblioteka.Run();
        }

    }
}
