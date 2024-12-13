using IKA.API.DataBase.Entities.Base;

namespace IKA.API.DataBase.Entities.Course;

public class CourseCard:BaseEntity
{
    public int Order { get; set; } //higher order means higher priority
    public string CardName { get; set; }
    public string CardShortDescription { get; set;}
    public string CardShortImageUrl { get; set; }
}