using FluentValidation;
using IKA.API.DataBase.Entities.Course;

namespace IKA.API.Validators;

public class CourseValidator:AbstractValidator<Course>
{
    public CourseValidator()
    {
        //id rules for  Add
        RuleSet("Add", () =>
        {
            //Course Rules
            RuleFor(x=>x).NotNull().WithMessage("Course must be set");
            RuleFor(x => x.Id).Equal(0).WithMessage("Id must be null");
            RuleFor(x=>x.Price).GreaterThan(-1).NotEqual(0).WithMessage("Price must be set");
            RuleFor(x=>x.StartDate).NotEmpty().WithMessage("Start date must be set");
            RuleFor(x=>x.Duration).NotEmpty().WithMessage("Duration must be set");
            
            //rating Data Rules
            RuleFor(x=>x.RatingData).NotNull().WithMessage("Rating data must be set");
            RuleFor(x=>x.RatingData.Id).Equal(0).WithMessage("Card Id must be null");
            RuleFor(x=>x.RatingData.GeneralRating).NotEmpty().GreaterThan(-1).WithMessage("General rating must be set");
            RuleFor(x=>x.RatingData.ReviewCount).GreaterThan(-1).WithMessage("Review count must be set");
            
            //Course Card Rules
            RuleFor(x=>x.CourseCard).NotNull().WithMessage("Course card must be set");
            RuleFor(x=>x.CourseCard.Id).Equal(0).WithMessage("Card Id must be null");
            RuleFor(x=>x.CourseCard).NotNull().WithMessage("Course card must be set");
            RuleFor(x=>x.CourseCard.CardName).NotEmpty().WithMessage("Card name must be set");
            RuleFor(x=>x.CourseCard.CardShortDescription).NotEmpty().WithMessage("Card short description must be set");
            
            //Course Details Rules
            RuleFor(x=>x.CourseDetails).NotNull().WithMessage("Course details must be set");
            RuleFor(x=>x.CourseDetails.Id).Equal(0).WithMessage("Details Id must be null");
            RuleFor(x=>x.CourseDetails.DetailName).NotEmpty().WithMessage("Detail name must be set");
            RuleFor(x=>x.CourseDetails.DetailDescription).NotEmpty().WithMessage("Detail description must be set");
            RuleFor(x=>x.CourseDetails.EducationProcessDescription).NotEmpty().WithMessage("Education process description must be set");
            RuleFor(x=>x.CourseDetails.CarrierOpportunies).NotNull().WithMessage("Carrier opportunities must be set");
            //Course Content Rules
            RuleFor(x=>x.CourseDetails.CourseContent).NotNull().WithMessage("Course content must be set");
            RuleFor(x=>x.CourseDetails.CourseContent.Id).Equal(0).WithMessage("Content Id must be null");
            RuleFor(x=>x.CourseDetails.CourseContent.Header).NotEmpty().WithMessage("Header must be set");
            RuleFor(x=>x.CourseDetails.CourseContent.subHeaders).NotNull().WithMessage("Sub headers must be set");
            
        });
        
    }
    
}