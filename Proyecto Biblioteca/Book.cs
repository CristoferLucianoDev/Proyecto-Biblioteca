using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Biblioteca;

public class Book(int id, string title, int year, string gender)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public int Year { get; set; } = year;
    public string Gender { get; set; } = gender;

    public string GetBookInfo()
    {
        return $"ID: {Id}, Title: {Title}, Year: {Year}, Gender: {Gender}";
    }
}
