using System;

public class Lecture
{
    public string Description { get; set; }
    public string Topic { get; set; }

    public Lecture(string description, string topic)
    {
        Description = description;
        Topic = topic;
    }
}

public class PracticalLesson
{
    public string Description { get; set; }
    public string TaskCondition { get; set; }
    public string Solution { get; set; }

    public PracticalLesson(string description, string taskCondition, string solution)
    {
        Description = description;
        TaskCondition = taskCondition;
        Solution = solution;
    }
}

public class Training
{
    private object[] lecturesAndPracticals;
    private int count;

    public Training(int capacity)
    {
        lecturesAndPracticals = new object[capacity];
        count = 0;
    }

    public void Add(object item)
    {
        if (count < lecturesAndPracticals.Length)
        {
            lecturesAndPracticals[count] = item;
            count++;
        }
    }

    public bool IsPractical()
    {
        foreach (var item in lecturesAndPracticals)
        {
            if (item is Lecture)
            {
                return false;
            }
        }
        return true;
    }

    public Training Clone()
    {
        Training clonedTraining = new Training(lecturesAndPracticals.Length);
        for (int i = 0; i < count; i++)
        {
            if (lecturesAndPracticals[i] is Lecture lecture)
            {
                clonedTraining.Add(new Lecture(lecture.Description, lecture.Topic));
            }
            else if (lecturesAndPracticals[i] is PracticalLesson practical)
            {
                clonedTraining.Add(new PracticalLesson(practical.Description, practical.TaskCondition, practical.Solution));
            }
        }
        return clonedTraining;
    }
}

public class Program
{
    public static void Main()
    {
        Training training = new Training(5);
        training.Add(new Lecture("Intro to C#", "Basics"));
        training.Add(new PracticalLesson("Practice on loops", "Solve problems on loops", "Solution link"));

        Console.WriteLine($"Is training purely practical? {training.IsPractical()}");

        Training clonedTraining = training.Clone();
        Console.WriteLine($"Is cloned training purely practical? {clonedTraining.IsPractical()}");
    }
}
