using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

public class Lecture : Lesson
{
    public string Topic { get; set; }

    public Lecture(string description, string topic) : base(description)
    {
        Topic = topic;
    }
}

}
