using System;

public class PracticalLesson : Lesson
{
    public string TaskCondition { get; set; }
    public string Solution { get; set; }

    public PracticalLesson(string description, string taskCondition, string solution) 
        : base(description)
    {
        TaskCondition = taskCondition;
        Solution = solution;
    }
}
