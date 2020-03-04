using IST_Task.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace IST_Task.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NID { get; set; }
        public DateTime Birthdate{ get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}