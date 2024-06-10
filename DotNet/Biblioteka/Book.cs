namespace Biblioteka
{
    public class Book
    {
        public Book(int id, string title, string author, int year, string isbn)
        {
            ID = id;
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
        }

        public int ID { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
    }
}
