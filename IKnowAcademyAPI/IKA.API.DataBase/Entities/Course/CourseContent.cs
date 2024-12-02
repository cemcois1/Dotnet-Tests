using IKA.API.DataBase.Entities.Base;

namespace IKA.API.DataBase.Entities.Course;

/// <summary>
/// This class answers the question "What is the course Content by Lesson?"
/// </summary>
public class CourseContent  :BaseEntity
{
    public string Header { get; set; }//eg. "Course Content"

    List<string> subHeaders { get; set; }//eg. "Lesson 1", "Week 2"
    
    List<string> shortDescription { get; set; }//eg. "Introduction to C#", "Introduction to Java"

    List<string> content { get; set; }//eg. "C# is a programming language"
    
}