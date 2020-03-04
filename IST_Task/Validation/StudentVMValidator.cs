using FluentValidation;
using IST_Task.DAL;
using IST_Task.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IST_Task.Validation
{
    public class StudentVMValidator : AbstractValidator<StudentVM>
    {
        public StudentVMValidator()//ApplicationContext context)
        {
            //_context = context;

            // FullName Validations
            RuleFor(x => x.FullName).NotEmpty().WithMessage("*Required")
                .Length(4,10).WithMessage("Minimum Length Is 4 Characters And Maximum Length Is 10 Characters")
                .Matches(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]+[\s\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]*")
                .WithMessage("Only Arabic and English Letters Allowed");

            // Birthdate Validations
            RuleFor(x => x.NID).NotEmpty().WithMessage("*Required")
                .Length(4, 20).WithMessage("Minimum Length Is 4 Digits And Maximum Length Is 10 Digits")
                .Matches("\\d+")
                .WithMessage("Only Digits are Allowed");

            // Birthdate Validations
            RuleFor(x => x.Birthdate)
                .Must(IsAllowedDate)
                .WithMessage("Birthdate Must be between 1-1-1980 and 1-1-2000");
                //.ExclusiveBetween(new DateTime(1980, 1, 1), new DateTime(2000, 1, 1))

            // SchoolId Validations
            RuleFor(x => x.SchoolId).NotNull().GreaterThan(0)
                .WithMessage("School Id Must be Greater Than 0");
        }

        private bool IsAllowedDate(DateTime date)
        {
            return date >= new DateTime(1980,1, 1) && date <= new DateTime( 2000,1, 1);
        }
    }
}  
