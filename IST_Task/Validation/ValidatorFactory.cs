using FluentValidation;
using IST_Task.DAL;
using IST_Task.ViewModels;
using System;
using System.Collections.Generic;

namespace IST_Task.Validation
{
    public class ValidatorFactory : ValidatorFactoryBase  
    {  
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            validators.Add(typeof(IValidator<StudentVM>), new StudentVMValidator());
            validators.Add(typeof(IValidator<SchoolVM>), new SchoolVMValidator());
        }

        public override IValidator CreateInstance(Type validatorType)  
        {  
            IValidator validator;  
            if (validators.TryGetValue(validatorType, out validator))  
            {  
                return validator;  
            }  
            return validator;  
        }  
    }  
}  
