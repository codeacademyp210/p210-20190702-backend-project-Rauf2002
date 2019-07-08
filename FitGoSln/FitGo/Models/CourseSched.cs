//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitGo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseSched
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Start { get; set; }
        public Nullable<System.DateTime> Finish { get; set; }
        public string Description { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> RoomId { get; set; }
        public Nullable<int> TrainerId { get; set; }
        public bool Status { get; set; }
        public string Day { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Room Room { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
