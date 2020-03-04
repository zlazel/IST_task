using FluentValidation;
using IST_Task.DAL;
using IST_Task.ViewModels;
using System.Linq;

namespace IST_Task.Validation
{
    public class SchoolVMValidator : AbstractValidator<SchoolVM>
    {
        public SchoolVMValidator()
        {
            // FullName Validations
            RuleFor(x => x.Name).NotEmpty().WithMessage("*Required")
                .MinimumLength(3).WithMessage("Minimum Length Is 3 Characters")
                .MaximumLength(30).WithMessage("Minimum Length Is 30 Characters")
                .Matches(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]+[\s\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]*")
                .WithMessage("Only Arabic and English Letters Allowed");
        }
    }
}  
