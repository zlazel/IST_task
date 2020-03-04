using IST_Task.Models;
using System;
using System.Collections.Generic;
using School = IST_Task.Models.School;

namespace IST_Task.DAL
{
    public class ApplicationInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var InternationSchoolStudents = new List<Student>()
            {
                new Student { FullName = "Ahmed Omar" , Birthdate = new DateTime(2000, 1,1) , NID = "1111"},
                new Student { FullName = "Ahmed Ali" , Birthdate = new DateTime(1999, 6,19) , NID = "1112"},
                new Student { FullName = "Amr Abbas" , Birthdate = new DateTime(1999, 4,2) , NID = "1113"},
            };
            
            var SecodarySchoolStudents = new List<Student>()
            {
                new Student { FullName = "Fatma A" , Birthdate = new DateTime(2000, 1,1), NID = "2111"},
                new Student { FullName = "Hasnaa Ali" , Birthdate = new DateTime(1999, 6,19) , NID = "2112"},
                new Student { FullName = "Enas Z" , Birthdate = new DateTime(1998, 4,2), NID = "2113"},
                new Student { FullName = "Ola Omar" , Birthdate = new DateTime(1998, 2,5)  , NID = "2114"},
            };

            var Schools = new List<School>()
            {
                new School
                {
                    Name = "Internation School" ,
                    Students = InternationSchoolStudents
                },
                new School
                {
                    Name = "Secondary School" ,
                    Students = SecodarySchoolStudents
                },
                new School { Name = "Prep School" },
                new School { Name = "Primary School" }
            };

            context.Schools.AddRange(Schools);
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}