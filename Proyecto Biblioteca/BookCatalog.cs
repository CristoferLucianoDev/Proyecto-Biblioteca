namespace Proyecto_Biblioteca;

public class BookCatalog
{
    private const int Capacity = 20;
    private readonly Book[] _books = new Book[Capacity];
    private int _count = 0;

    public bool AddBook(Book book)
    {
        if (_count >= Capacity)
        {
            return false;
        }
        _books[_count] = book;
        _count++;
        return true;
    }

    private int FindIndexById(int id)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_books[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }

    public Book[] GetBooks()
    {
        Book[] result = new Book[_count];

        for (int i = 0; i < _count; i++)
        {
            result[i] = _books[i];
        }

        return result;
    }

    public Book? FindById(int id)
    {
        int index = FindIndexById(id);
        if (index != -1)
        {
            return _books[index];
        }
        return null;
    }

    public bool UpdateBook(int id, string title, int year, string gender)
    {
        int index = FindIndexById(id);
        if (index != -1)
        {
            _books[index].Title = title;
            _books[index].Year = year;
            _books[index].Gender = gender;
            return true;
        }
        return false;
    }

    public bool RemoveBook(int id)
    {
        int index = FindIndexById(id);
        if (index != -1)
        {
            for (int i = index; i < _count - 1; i++)
            {
                _books[i] = _books[i + 1];
            }
            _books[_count - 1] = null!;
            _count--;
            return true;
        }
        return false;
    }
}
