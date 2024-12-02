using IKA.API.DataBase.Entities.Base;

namespace IKA.API.DataBase.Entities.Course;

public class Course:BaseEntity
{
    //general data for course
    public int Price { get; set; }
    public DateTime StartDate { get; set; }
    public string Duration { get; set; }
    
    public RatingData RatingData { get; set; }
    public CourseCard CourseCard { get; set; }
    public CourseDetails CourseDetails { get; set; }
}
