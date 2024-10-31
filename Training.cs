using System;
using System.Collections.Generic;


public class Training
{
    private Lesson[] lessons;

    public Training(int numberOfLessons)
    {
        lessons = new Lesson[numberOfLessons];
    }

    public void Add(Lesson lesson, int index)
    {
        lessons[index] = lesson;
    }

    public bool IsPractical()
    {
        foreach (var lesson in lessons)
        {
            if (lesson is not PracticalLesson)
            {
                return false;
            }
        }
        return true;
    }

    public Training Clone()
    {
        Training clonedTraining = new Training(lessons.Length);
        for (int i = 0; i < lessons.Length; i++)
        {
            clonedTraining.Add(lessons[i].Clone(), i);
        }
        return clonedTraining;
    }
}
