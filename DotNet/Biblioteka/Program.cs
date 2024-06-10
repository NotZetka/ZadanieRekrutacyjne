using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka
{
    class Program
    {
        static List<Book> books = new List<Book>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Dodaj książkę");
                Console.WriteLine("2. Wyswietl ksiazki");
                Console.WriteLine("3. Edytuj książkę");
                Console.WriteLine("4. Usuń książkę");
                Console.WriteLine("5. Wyjdź");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        DisplayBooks();
                        break;
                    case "3":
                        UpdateBook();
                        break;
                    case "4":
                        DeleteBook();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Błędny wybór spróbuj ponwnie");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Book book = new Book();
            book.ID = nextId++;

            Console.Write("Podaj tytuł: ");
            book.Title = Console.ReadLine();

            Console.Write("Podaj autora: ");
            book.Author = Console.ReadLine();

            Console.Write("Podaj rok: ");
            int year = 0;
            while(!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Rok musi być liczbą");
                Console.Write("Podaj rok: ");
            }
            book.Year = year;

            Console.Write("Podaj ISBN: ");
            book.ISBN = Console.ReadLine();

            books.Add(book);
            Console.WriteLine("Książka dodana");
        }

        static void DisplayBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Brak dostępnych książek");
            }
            else
            {
                Console.WriteLine("Książki:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.ID}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, ISBN: {book.ISBN}");
                }
            }
        }

        static void UpdateBook()
        {
            Console.Write("Podaj ID książki do edycji: ");
            int id = int.Parse(Console.ReadLine());

            var book = books.FirstOrDefault(b => b.ID == id);
            if (book == null)
            {
                Console.WriteLine("Nie znaleziono książki.");
                return;
            }

            Console.Write("Podaj nowy tytuł (pozostaw puste by nie zmieniać): ");
            string title = Console.ReadLine();
            if (!string.IsNullOrEmpty(title))
            {
                book.Title = title;
            }

            Console.Write("Podaj nowego autora (pozostaw puste by nie zmieniać): ");
            string author = Console.ReadLine();
            if (!string.IsNullOrEmpty(author))
            {
                book.Author = author;
            }

            Console.Write("Podaj nowy rok wydania (pozostaw puste by nie zmieniać): ");
            string yearInput = Console.ReadLine();
            if (int.TryParse(yearInput, out int year))
            {
                book.Year = year;
            }

            Console.Write("Podaj nowy ISBN (pozostaw puste by nie zmieniać): ");
            string isbn = Console.ReadLine();
            if (!string.IsNullOrEmpty(isbn))
            {
                book.ISBN = isbn;
            }

            Console.WriteLine("Ksiażka została zedytowana");
        }

        static void DeleteBook()
        {
            Console.Write("Podaj ID książki do usunięcia: ");
            int id = int.Parse(Console.ReadLine());

            var book = books.FirstOrDefault(b => b.ID == id);
            if (book == null)
            {
                Console.WriteLine("Książki nie znaleziono.");
                return;
            }

            books.Remove(book);
            Console.WriteLine("Książka została usunięta.");
        }
    }
}
