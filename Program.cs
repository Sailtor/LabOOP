Bookery psu = new();
ShowCounters show = new(Book.PrintBookCount);
show += Bookery.PrintBookCount;
int i;
do
{
    GC.Collect();
    Console.WriteLine($" Choose option \n 1. Add book \n 2. Add 2 Defaults \n 3. Redact book info \n 4. Delete book \n 5. Show all books \n 6. Compare books \n 7. Exit ");
    i = Convert.ToInt32(Console.ReadLine());
    switch (i)
    {
        case 1:
            {
                int i1;
                do
                {
                    Console.WriteLine($" 1. Add book \n 2. Add Read Book \n 3. Add Main Book \n 4. Exit ");
                    i1 = Convert.ToInt32(Console.ReadLine());
                    switch (i1)
                    {
                        case 1:
                            {
                                Book b1 = new();
                                psu+=b1;
                            }
                            break;
                        case 2:
                            {
                                ReadBook b1 = new();
                                psu += b1;
                            }
                            break;
                        case 3:
                            {
                                MainBook b1 = new();
                                psu += b1;
                            }
                            break;
                    }
                }
                while (i1 != 4);
            }
            break;
        case 2:
            {
                psu++;
                ++psu;
            }
            break;
        case 3:
            {
                psu.RedactBook();
            }
            break;
        case 4:
            {
                psu.DeleteBook();
            }
            break;
        case 5:
            {
                psu <<= 1945;
            }
            break;
        case 6:
            {
                int b1;
                int b2;
                Console.WriteLine($" Enter first book number");
                b1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($" Enter second book number");
                b2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($" Book1 < Book2 = {b1 < b2}");
                Console.WriteLine($" Book1 > Book2 = {b1 > b2}");
                Console.WriteLine($" Book1 == Book2 = {b1 == b2}");
                Console.WriteLine($" Book1 != Book2 = {b1 != b2}");
            }
            break;
        default: break;
    }
}
while (i != 7);
class Bookery
{
    private static int _bookeryBookCount;
    private List<Book> books = new(2048);
    private List<MainBook> booksInherit = new(2048);

    public Book this[int i]
    {
        get { return books[i]; }
        set { books[i] = value; }
    }

    public void AddBook(Book b)
    {
        Console.WriteLine(" Choose List to add: \n 1. Books list \n 2. Main books List");
        int i = Convert.ToInt32(Console.ReadLine());
        if (i == 1) { books.Add(b); _bookeryBookCount++; } else { booksInherit.Add((MainBook)b); }
    }
    public void PrintBooks()
    {
        int i;
        Console.WriteLine(" Choose List to show: \n 1. Books list \n 2. Main books List");
        i = Convert.ToInt32(Console.ReadLine());
        if (i == 1)
        {
            i = 0;
            foreach (Book b in books)
            {
                Console.Write($"{i + 1}. ");
                this[i].Print();
                Console.Write("\n");
                i++;
            }
        }
        else
        {
            i = 0;
            foreach (MainBook b in booksInherit)
            {
                Console.Write($"{i + 1}. ");
                booksInherit[i].Print();
                Console.Write("\n");
                i++;
            }
        }

    }
    public void DeleteBook()
    {
        Console.WriteLine(" Choose book number to delete:");
        int i = Convert.ToInt32(Console.ReadLine());
        this[i - 1].Dispose();
        books.RemoveAt(i - 1);
        _bookeryBookCount--;
        GC.Collect();
    }
    public void RedactBook()
    {
        Console.WriteLine(" Choose book number to redact:");
        int i = Convert.ToInt32(Console.ReadLine());
        this[i - 1].Redact();
    }
    public static void PrintBookCount()
    {
        Console.WriteLine($"Bookery static Book counter: {_bookeryBookCount}");
    }
    public static Bookery operator +(Bookery bookery, Book b)
    {
        bookery.AddBook(b);
        return bookery;
    }
    public static Bookery operator ++(Bookery bookery)
    {
        bookery.AddBook(bookery[0]);
        return bookery;
    }
    public static Bookery operator << (Bookery bookery, int d)
    {
        bookery.PrintBooks();
        return null;
    }
}
class Book : IDisposable
{
    private static int _bookCount;
    private string? _name;
    private int _id;
    private string? _person;

    public string? Name
    {
        get => _name;
        set
        {
            if (value == "0")
            {
                _name = "Undefined";
            }
            else
            {
                _name = value;
            }
        }
    }
    public int Id { get => _id; set => _id = value; }
    public string? Person
    {
        get => _person;
        set
        {
            if (value == "0")
            {
                _person = "Undefined";
            }
            else
            {
                _person = value;
            }
        }
    }

    public Book()
    {
        Console.WriteLine(" Enter book Title (type 0 to skip): ");
        Name = Console.ReadLine();
        Console.WriteLine(" Enter book ID (type 0 to skip): ");
        Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(" Enter book Owner (type 0 to skip): ");
        Person = Console.ReadLine();
        Console.WriteLine("Book Constructor v2");
        _bookCount++;
    }
    public Book(Book b)
    {
        Name = b.Name;
        Id = b.Id;
        Person = b.Person;
        Console.WriteLine("Book Copying Constructor");
    }

    public Book(ref Book b)
    {
        Name = b.Name;
        Id = b.Id;
        Person = b.Person;
        b.Dispose();
        GC.Collect();
        Console.WriteLine("Book Moving Constructor");
    }
    ~Book()
    {
        Console.WriteLine("Book Destructor");
    }

    public virtual void Print()
    {
        Console.Write($"| Book Title: {Name} | Book ID: {Id} | Person: {Person} |");
    }
    public void Redact()
    {
        int i = 0;
        do
        {
            Console.WriteLine($"Choose option \n 1. Change book Title \n 2. Change book ID \n 3. Change owner \n 4. Exit");
            i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    {
                        Console.WriteLine($"Choose new Title: ");
                        Name = Console.ReadLine();
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine($"Choose new ID: ");
                        Id = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine($"Choose new Owner: ");
                        Person = Console.ReadLine();
                    }
                    break;
                default: break;
            }
        }
        while (i != 4);
    }
    public void Dispose()
    {
        _bookCount--;
        Console.WriteLine("Book Disposer");
    }
    public static void PrintBookCount()
    {
        Console.WriteLine($"Static Book counter: {_bookCount}");
    }
}
class MainBook : Book
{
    private int _age;
    public int Age { get => _age; set => _age = value; }
    public MainBook() : base()
    {
        Console.WriteLine(" Enter book Age (type 0 to skip): ");
        Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("MainBook Constructor v2");
    }
    ~MainBook()
    {
        Console.WriteLine("MainBook Destructor");
    }

    public new void Dispose()
    {
        Console.WriteLine("MainBook Disposer");
    }
    public override void Print()
    {
        base.Print();
        Console.Write($" Book age: {Age} |");
    }
    public static bool operator <(MainBook b1, MainBook b2)
    {
        return b1.Age < b2.Age;
    }
    public static bool operator >(MainBook b1, MainBook b2)
    {
        return b1.Age > b2.Age;
    }
    public static bool operator == (MainBook b1, MainBook b2)
    {
        return b1.Age == b2.Age;
    }
    public static bool operator !=(MainBook b1, MainBook b2)
    {
        return !(b1.Age == b2.Age);
    }
}
class ReadBook : Book
{
    private int _stand;
    public int Stand { get => _stand; set => _stand = value; }

    public ReadBook() : base()
    {
        Console.WriteLine(" Enter book Stand (type 0 to skip): ");
        Stand = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("ReadBook Constructor v2");
    }
    ~ReadBook()
    {
        Console.WriteLine("ReadBook Destructor");
    }
    public new void Dispose()
    {
        Console.WriteLine("ReadBook Disposer");
    }
    public override void Print()
    {
        base.Print();
        Console.Write($" Book Stand: {Stand} |");
    }

    public static bool operator <(ReadBook b1, ReadBook b2)
    {
        return b1.Stand < b2.Stand;
    }
    public static bool operator >(ReadBook b1, ReadBook b2)
    {
        return b1.Stand > b2.Stand;
    }
    public static bool operator ==(ReadBook b1, ReadBook b2)
    {
        return b1.Stand == b2.Stand;
    }
    public static bool operator !=(ReadBook b1, ReadBook b2)
    {
        return !(b1.Stand == b2.Stand);
    }
}

delegate void ShowCounters();