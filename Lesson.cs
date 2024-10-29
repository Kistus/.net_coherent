using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

public abstract class Lesson
{
    public string Description { get; set; }

    protected Lesson(string description)
    {
        Description = description;
    }
}

}
