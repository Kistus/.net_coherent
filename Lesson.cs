

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
