using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitGo.Models
{
    public class ViewModelHome
    {
        public List<Trainer> Trainers { get; set; }
        public List<Users> Users{ get; set; }
        public List<Course> Courses{ get; set; }
        public List<Room> Rooms{ get; set; }
        public List<CourseSched> CourseScheds{ get; set; }
    }
}