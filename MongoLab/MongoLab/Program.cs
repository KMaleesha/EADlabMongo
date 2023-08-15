using MongoDB.Driver;

namespace MongoLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Establish mongoDB connection
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient(settings);

            //Create database "LibraryDB" or retrieve if exists
            var mongoDb = client.GetDatabase("LibraryDB");
            //Create collection "BookStore" or retrieve if exists
            var collection = mongoDb.GetCollection<BookStore>("BookStore");

            //Create a book list
            List<BookStore> bookStores = new List<BookStore>
                {
                     new BookStore
                     {
                        BookTitle = "MongoDB Basics",
                        ISBN = "8767687689898yu",
                        Auther = "Tanya",
                        Category = "NoSQL DBMS",
                        Price = 456
                     },
                     new BookStore
                     {
                        BookTitle = "C# Basics",
                        ISBN = "27758987689898yu",
                        Auther = "Tanvi",
                        Category = "Programming Languages",
                        TotalPages = 376,
                        Price = 289
                     },
                     new BookStore
                     {
                        BookTitle = "SQL Server Basics",
                        ISBN = "117675787689898yu",
                        Auther = "Tushar",
                        Category = "RDBMS",
                        TotalPages = 250,
                        Price = 478
                     },
                     new BookStore
                     {
                        BookTitle = "Entity Framework Basics",
                        ISBN = "6779799933389898yu",
                        Auther = "Somya",
                        Category = "ORM tool",
                        TotalPages = 175,
                        Price = 289
                     }
                 };

            //Insert books to the "BookStore" collection one by one
            foreach (BookStore bookStore in bookStores)
            {
                collection.InsertOne(bookStore);
            }
            Console.ReadLine();

            //Query data
            var bookCount = collection.AsQueryable().Where(b => b.TotalPages > 200);
            Console.WriteLine("\nCount of books having more than 200 pages is => " +
            bookCount.Count());
            var book = collection.AsQueryable().Where(b => b.BookTitle.StartsWith("Mongo"));
            Console.WriteLine("\nThe book which title starts with 'Mongo' is => " +
            book.First().BookTitle);
            var cheapestBook = collection.AsQueryable().OrderBy(b => b.Price).First();
            Console.WriteLine("\nCheapest book is => " + cheapestBook.BookTitle);
            var bookWithISBN = collection.AsQueryable().Single(b => b.ISBN == "6779799933389898yu");
            Console.WriteLine("\nBook with ISBN number 6779799933389898yu is => " +
            bookWithISBN.BookTitle);

            Console.ReadLine();

        }
    }
}