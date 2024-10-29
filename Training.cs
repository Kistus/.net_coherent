using System;
using System.Collections.Generic;

public class Training
{
    private List<Lesson> lessons;

    public Training()
    {
        lessons = new List<Lesson>();
    }

    public void Add(Lesson lesson)
    {
        lessons.Add(lesson);
    }

    public bool IsPractical()
    {
        // Check if all lessons are of type PracticalLesson
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
        Training clonedTraining = new Training();
        foreach (var lesson in lessons)
        {
            if (lesson is Lecture lecture)
            {
                clonedTraining.Add(new Lecture(lecture.Description, lecture.Topic));
            }
            else if (lesson is PracticalLesson practical)
            {
                clonedTraining.Add(new PracticalLesson(practical.Description, practical.TaskCondition, practical.Solution));
            }
        }
        return clonedTraining;
    }
}
