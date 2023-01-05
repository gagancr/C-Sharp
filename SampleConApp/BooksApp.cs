using System;//Default APIs
using Entities;//For the Entity class
using Repository;//Repo class
using SampleConApp; //Utilities

namespace Entities
{
    class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public int BookStock { get; set; } = 10;

        public void ShallowCopy(Book copy)
        {
            this.BookId = copy.BookId;
            this.BookStock = copy.BookStock;
            this.BookTitle = copy.BookTitle;
            this.Price = copy.Price;
            this.Publisher = copy.Publisher;
            this.Author = copy.Author;
        }

        public Book DeepCopy(Book copy)
        {
            Book book = new Book();
            book.ShallowCopy(copy);
            return book;
        }
    }
}
//datatype [] identifier = new datatype[size]
namespace Repository
{
    class BookRepository
    {
        private Book[] _books = null;
        private readonly int _size = 0;
        public BookRepository(int size)
        {
            _size = size;
            _books = new Book[_size];
        }

        public int AddNewBook(Book book)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] == null)
                {
                    _books[i] = book.DeepCopy(book);
                    return 1;//To exit
                }
            }
            return _size;
        }

        public Book FindBookById(int id)
        {
            foreach (Book b in _books)
            {
                if (b != null && b.BookId == id)
                    return b;
            }
            throw new Exception("No book found");
        }

        public void UpdateBook(Book book)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].BookId == book.BookId)
                {
                    _books[i].ShallowCopy(book);
                    return;//To exit
                }
            }
            throw new Exception("No book found to update");
        }

        public void RemoveBook(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].BookId == id)
                {
                    _books[i] = null;
                    return;//To exit
                }
            }
            throw new Exception("No book found to remove");
        }
        public string GetDetails(Book b)
        {
            return $"Id of the book is {b.BookId}\nName of the book is {b.BookTitle}\nAuthor of the book {b.Author}\nPrice of the book is {b.Price}\nPublisher of the book is {b.Publisher} Stock available is {b.BookStock} ";
        }

        public void UpdatingNewBook(int id, int response)
        {
            Book bb = FindBookById(id);
            Console.WriteLine(GetDetails(bb));
            switch (response)
            {
                case 1:
                    
                    string name1 = Utilities.Prompt("enter the name to update");
                    bb.BookTitle = name1;
                    Console.WriteLine("Bookname Updated");
                    Console.WriteLine(" ");
                    Console.WriteLine(GetDetails(bb));
                    break;

                case 2:
                    
                    string author1 = Utilities.Prompt("enter the author name to update");
                    bb.Author = author1;
                    Console.WriteLine("Author name Updated");
                    Console.WriteLine("\nUpdated Details \n");
                    Console.WriteLine(GetDetails(bb));
                    break;
                case 3:
                    
                    int price1 = Utilities.GetNumber("enter the price you want to update");
                    bb.Price = price1;
                    Console.WriteLine("price Updated");
                    Console.WriteLine("\nUpdated Details \n");
                    Console.WriteLine(GetDetails(bb));
                    break;
                case 4:
                    string publ = Utilities.Prompt("enter the publication name to update");
                    bb.Publisher = publ;
                    Console.WriteLine("Authorname Updated");
                    Console.WriteLine("\nUpdated Details \n");
                    Console.WriteLine(GetDetails(bb));
                    break;
                case 5:
                    int stocks = Utilities.GetNumber("enter the publication name to update");
                    bb.BookStock = stocks;
                    Console.WriteLine("\nUpdated Details \n");
                    Console.WriteLine(GetDetails(bb));
                    break;

                default:
                    Console.WriteLine("enter valid number");
                    break;
            }
        }

        public Book[] FindByAuthor(string author)
        {
            int count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.Author.Contains(author))
                {
                    count += 1;
                }
            }
            Book[] books = new Book[count];
            count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.Author.Contains(author))
                {
                    books[count] = book.DeepCopy(book);
                    count += 1;
                }
            }
            return books;
        }

        public Book[] FindByTitle(string title)
        {
            int count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.BookTitle.Contains(title))
                {
                    count += 1;
                }
            }
            Book[] books = new Book[count];
            count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.BookTitle.Contains(title))
                {
                    books[count] = book.DeepCopy(book);
                    count += 1;
                }
            }
            return books;
        }
    }
}

namespace UILayer
{
    enum Options
    {
        Add = 1, Remove, Author, Title, Update
    }
    class UIComponent
    {
        public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~BOOK STORE MANAGER SOFTWARE~~~~~~~~~~~~~~~~~~~\nTO ADD NEW BOOK------------------------>PRESS 1\nTO DELETE BOOK------------------------->PRESS 2\nTO FIND BOOK BY AUTHOR----------------->PRESS 3\nTO FIND BOOK BY TITLE------------------>PRESS 4\nTo UPDATE BOOK------------------------->PRESS 5\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";

        private static BookRepository repo;

        public static void Run()
        {
            int size = Utilities.GetNumber("Enter the no of Books U need for the Store");
            repo = new BookRepository(size);
            bool processing = true;
            do
            {
                Options option = (Options)Utilities.GetNumber(menu);
                processing = processMenu(option);
            } while (processing);
            Console.WriteLine("Thanks for Using our Application!!!");
        }

        private static bool processMenu(Options option)
        {
            switch (option)
            {
                case Options.Add:
                    AddingBookHelper();
                    break;
                case Options.Remove:
                    RemoveBookHelper();
                    break;
                case Options.Author:
                    FindingAuthorHelper();
                    break;
                case Options.Title:
                    FindByTitleHelper();
                    break;
                case Options.Update:
                    UpdateBookHelper();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void UpdateBookHelper()
        {
            int id = Utilities.GetNumber("enter the id to update details");
            Console.WriteLine("Enter 1 to update name\nEnter 2 to update author\nEnter 3 to update price\nEnter 4 to update publication\nEnter 5 to update Stock");
            int response = Utilities.GetNumber("enter");
            repo.UpdatingNewBook(id, response);
    
        }

        private static void FindByTitleHelper()
        {
            string name = Utilities.Prompt("Enter the name of the book to find ");
            Book[] temp = repo.FindByTitle(name);
            int count = 0;

            foreach (var item in temp)
            {
                Console.WriteLine("");
                Console.WriteLine(temp[count].BookTitle);
                count++;
            }
            if (count == 0)
                Console.WriteLine("Sorry!!! No book found with the name . " + name);
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Above are the books found with the name " + name);
            }
            Console.WriteLine("");
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }

        private static void FindingAuthorHelper()
        {
            string name = Utilities.Prompt("Enter the name of the author to find ");
           Book[]temp =repo.FindByAuthor(name);
            int count = 0;

            foreach (var item in temp)
            {
                Console.WriteLine("");
                Console.WriteLine(temp[count].BookTitle);
                count++;
            }
            if (count == 0)
                Console.WriteLine("Sorry!!! No Author found with the author name . " + name);
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Above are the Authors found with the author name " + name);
            }
            Console.WriteLine("");
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();

        }

        private static void RemoveBookHelper()
        {
            int id = Utilities.GetNumber("enter the id of the book you want to delete");
            repo.RemoveBook(id);
            Console.WriteLine("");
            Console.WriteLine("book was Removed successfully!!!");
            Console.WriteLine("");
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }

        private static void AddingBookHelper()
        {
            
            int id = Utilities.GetNumber("enter the id of the book");
            string name = Utilities.Prompt("enter the name of the book");
            string author = Utilities.Prompt("enter the name of the author");
            double price = Utilities.GetNumber("enter the price of the book");
            string publication = Utilities.Prompt("enter the publications of the book");
            // string bookStock = Utilities.Prompt("enter stock of the book");
            Book b = new Book { BookId = id, BookTitle = name, Author = author, Price = price, Publisher = publication };
            repo.AddNewBook(b);
            Console.WriteLine("");
            Console.WriteLine("book was added successfully!!!");
            Console.WriteLine("");
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }
    }
}

namespace TestingApp
{
    using Repository;
    using SampleConApp;
    using System;


    class App
    {
        static void Main(string[] args)
        {
            UILayer.UIComponent.Run();
        }
    }
}
