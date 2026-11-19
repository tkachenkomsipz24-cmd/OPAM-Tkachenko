using System;

namespace ConsoleApp
{
    struct Book
    {
        public string author;
        public int year;
        public string title;

        public Book(string author, int year, string title)
        {
            this.author = author;
            this.year = year;
            this.title = title;
        }

        public void Info()
        {
            Console.WriteLine($"Автор: {author} | Назва: \"{title}\" | Рік: {year}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Book[] books = new Book[]
            {
                new Book("Шевченко", 1840, "Кобзар"),
                new Book("Костенко", 1979, "Маруся Чурай"),
                new Book("Костенко", 1957, "Проміння землі"),
                new Book("Костенко", 2010, "Записки українського самашедшого"),
                new Book("Стус", 1970, "Зимові дерева"),
                new Book("Франко", 1883, "Захар Беркут")
            };

            Console.WriteLine("Усі книги в масиві:");
            foreach (Book b in books)
            {
                b.Info();
            }

            Console.Write("\nВведіть прізвище автора для пошуку: ");
            string searchAuthor = Console.ReadLine() ?? "";

            Console.WriteLine($"\nНазви книг автора {searchAuthor}, виданих після 1960 року:");
            bool found = false;

            foreach (Book b in books)
            {
                if (b.author.Equals(searchAuthor, StringComparison.OrdinalIgnoreCase) && b.year > 1960)
                {
                    Console.WriteLine($"- {b.title} ({b.year} р.)");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Книг цього автора, виданих після 1960 року, не знайдено.");
            }
        }
    }
}