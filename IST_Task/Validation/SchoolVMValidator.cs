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
                .MaximumLength(30).WithMessage("Minimum Length Is 30 Characters");
        }
    }
}  
