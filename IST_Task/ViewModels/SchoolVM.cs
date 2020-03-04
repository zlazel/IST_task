using IST_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IST_Task.ViewModels
{
    public class SchoolVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}