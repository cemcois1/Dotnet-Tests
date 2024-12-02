using IKA.API.DataBase.Entities.Base;

namespace IKA.API.DataBase.Entities.Course;

public class CourseDetails:BaseEntity
{
    public string DetailName { get; set; }
    public string DetailDescription { get; set; }
    public string EducationProcessDescription { get; set; } 
    public List<string> CarrierOpportunies { get; set; } //eg. "Software Developer", "Data Analyst"
    public CourseContent CourseContent { get; set; }
}