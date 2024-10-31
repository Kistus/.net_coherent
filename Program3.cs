using System;

public class Program3
{
    public static void Main()
    {
        Training training = new Training();
        training.Add(new Lecture("Intro to C#", "Basics"));
        training.Add(new PracticalLesson("loops", "problems on loops", "Solution"));

        Console.WriteLine($"practical? {training.IsPractical()}");

        Training clonedTraining = training.Clone();
        Console.WriteLine($"practical? {clonedTraining.IsPractical()}");
    }
}
