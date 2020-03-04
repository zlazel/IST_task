using System;
using System.ComponentModel.DataAnnotations;

namespace IST_Task.Models
{
    public class Student 
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NID { get; set; }
        public DateTime Birthdate{ get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}