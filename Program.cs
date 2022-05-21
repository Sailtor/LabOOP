int i;
do
{
    Console.WriteLine($" Choose type \n 1. Integer \n 2. Char \n 3. Book \n 4. Main Book \n 5. Read Book \n 6. Exit");
    i = Convert.ToInt32(Console.ReadLine());
    var rand = new Random();
    switch (i)
    {
        case 1:
            {
                Console.WriteLine($" Choose Array Size: ");
                BookeryGeneric<int> psu = new(Convert.ToInt32(Console.ReadLine()));
                for (int j = 0; j < psu.maxsize; j++)
                {
                    psu.AddBook(j + rand.Next(42));
                    Console.Write($"{j + 1}.{psu.GetItem(j)} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Max = {psu.Max()}");
                Console.WriteLine($"Min = {psu.Min()}");
                psu.Sort();
                Console.WriteLine($"Sorted:");
                for (int j = 0; j < psu.maxsize; j++)
                {
                    Console.Write($"{j + 1}.{psu.GetItem(j)} ");
                }
                Console.WriteLine();
                Console.WriteLine($" Choose Item to get index from: ");
                int iFind = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Index of item (non-existent if 0): {psu.FindItem(iFind) + 1}");
            }
            break;
        case 2:
            {
                Console.WriteLine($" Choose Array Size: ");
                BookeryGeneric<Char> psu = new(Convert.ToInt32(Console.ReadLine()));
                for (int j = 0; j < psu.maxsize; j++)
                {
                    psu.AddBook((char)(rand.Next(25) + 97));
                    Console.Write($"{j + 1}.{psu.GetItem(j)} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Max = {psu.Max()}");
                Console.WriteLine($"Min = {psu.Min()}");
                psu.Sort();
                Console.WriteLine($"Sorted:");
                for (int j = 0; j < psu.maxsize; j++)
                {
                    Console.Write($"{j + 1}.{psu.GetItem(j)} ");
                }
                Console.WriteLine();
                Console.WriteLine($" Choose Item to get index from: ");
                char iFind = Console.ReadLine()[0];
                Console.WriteLine($"Index of item (non-existent if 0): {psu.FindItem(iFind) + 1}");
            }
            break;
        case 3:
            {
                Console.WriteLine($" Choose Array Size: ");
                BookeryGeneric<Book> psu = new(Convert.ToInt32(Console.ReadLine()));
                for (int j = 0; j < psu.maxsize; j++)
                {
                    psu.AddBook(new() { Id = rand.Next(42) });
                    Console.Write($"{j + 1}.");
                    psu.GetItem(j).Print();
                    Console.WriteLine();
                }
                Console.WriteLine($"Max Book Id = {psu.Max().Id}");
                Console.WriteLine($"Min Book Id = {psu.Min().Id}");
                psu.Sort();
                Console.WriteLine($"Sorted:");
                for (int j = 0; j < psu.maxsize; j++)
                {
                    Console.Write($"{j + 1}.");
                    psu.GetItem(j).Print();
                    Console.WriteLine();
                }
                Console.WriteLine($" Choose Item to get index from (search by Id): ");
                int iFind = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Index of item (non-existent if 0): {psu.FindItem(new() { Id = iFind }) + 1}");
            }
            break;
        case 4:
            {
                Console.WriteLine($" Choose Array Size: ");
                BookeryGeneric<MainBook> psu = new(Convert.ToInt32(Console.ReadLine()));
                for (int j = 0; j < psu.maxsize; j++)
                {
                    psu.AddBook(new() { Age = rand.Next(42) });
                    Console.Write($"{j + 1}.");
                    psu.GetItem(j).Print();
                    Console.WriteLine();
                }
                Console.WriteLine($"Max Book Age = {psu.Max().Age}");
                Console.WriteLine($"Min Book Age = {psu.Min().Age}");
                psu.Sort();
                Console.WriteLine($"Sorted:");
                for (int j = 0; j < psu.maxsize; j++)
                {
                    Console.Write($"{j + 1}.");
                    psu.GetItem(j).Print();
                    Console.WriteLine();
                }
                Console.WriteLine($" Choose Item to get index from (search by Age): ");
                int iFind = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Index of item (non-existent if 0): {psu.FindItem(new() { Age = iFind }) + 1}");
            }
            break;
        case 5:
            {
                Console.WriteLine($" Choose Array Size: ");
                BookeryGeneric<ReadBook> psu = new(Convert.ToInt32(Console.ReadLine()));
                for (int j = 0; j < psu.maxsize; j++)
                {
                    psu.AddBook(new() { Stand = rand.Next(42) });
                    Console.Write($"{j + 1}.");
                    psu.GetItem(j).Print();
                    Console.WriteLine();
                }
                Console.WriteLine($"Max Book Stand = {psu.Max().Stand}");
                Console.WriteLine($"Min Book Stand = {psu.Min().Stand}");
                psu.Sort();
                Console.WriteLine($"Sorted:");
                for (int j = 0; j < psu.maxsize; j++)
                {
                    Console.Write($"{j + 1}.");
                    psu.GetItem(j).Print();
                    Console.WriteLine();
                }
                Console.WriteLine($" Choose Item to get index from (search by Stand): ");
                int iFind = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Index of item (non-existent if 0): {psu.FindItem(new() { Stand = iFind }) + 1}");
            }
            break;
        default: break;
    }
} while (i != 6);
class BookeryGeneric<T> where T : IComparable<T>
{

    private List<T> books;
    public int maxsize = 0;
    private int count = 0;
    public BookeryGeneric(int n)
    {
        books = new();
        maxsize = n;
    }

    public void AddBook(T book)
    {
        if (count < maxsize)
        {
            books.Add(book);
            count++;
        }
    }
    public T GetItem(int i)
    {
        return books[i];
    }

    public int FindItem(T obj)
    {
        int index = -1;
        for (int i = 0; i < count; i++)
        {
            if (books[i].CompareTo(obj) == 0)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public T Min()
    {
        T minValue = books[0];
        foreach (T item in books)
        {
            if (item.CompareTo(minValue) < 0)
            {
                minValue = item;
            }
        }
        return minValue;
    }
    public T Max()
    {
        T maxValue = books[0];
        foreach (T item in books)
        {
            if (item.CompareTo(maxValue) > 0)
            {
                maxValue = item;
            }
        }
        return maxValue;
    }

    public void Sort()
    {
        books.Sort();
    }

}

class Book : IComparable<Book>
{
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
        Id = 0;
        Name = "0";
        Person = "0";
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
        GC.Collect();
        Console.WriteLine("Book Moving Constructor");
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

    public int CompareTo(Book other)
    {
        if (this.Id < other.Id)
        {
            return -1;
        }
        else
        {
            if (Id > other.Id)
            {
                return 1;
            }
            else return 0;
        }
    }
}
class MainBook : Book, IComparable<MainBook>
{
    private int _age;
    public int Age { get => _age; set => _age = value; }
    public MainBook() : base()
    {
        Age = 0;
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
    public static bool operator ==(MainBook b1, MainBook b2)
    {
        return b1.Age == b2.Age;
    }
    public static bool operator !=(MainBook b1, MainBook b2)
    {
        return !(b1.Age == b2.Age);
    }
    public int CompareTo(MainBook other)
    {
        if (Age < other.Age)
        {
            return -1;
        }
        else
        {
            if (Age > other.Age)
            {
                return 1;
            }
            else return 0;
        }
    }
}
class ReadBook : Book, IComparable<ReadBook>
{
    private int _stand;
    public int Stand { get => _stand; set => _stand = value; }

    public ReadBook() : base()
    {
        Stand = 0;
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
    public int CompareTo(ReadBook other)
    {
        if (Stand < other.Stand)
        {
            return -1;
        }
        else
        {
            if (Stand > other.Stand)
            {
                return 1;
            }
            else return 0;
        }
    }
}