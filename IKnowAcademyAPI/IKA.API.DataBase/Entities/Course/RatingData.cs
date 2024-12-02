using IKA.API.DataBase.Entities.Base;

namespace IKA.API.DataBase.Entities.Course;

/// <summary>
/// Dummy Class for Display RatingData 
/// </summary>
public class RatingData:BaseEntity
{
    public int CourseId { get; set; }
    //rating and review for course
    public float GeneralRating { get; set; }
    public int ReviewCount { get; set; }
}