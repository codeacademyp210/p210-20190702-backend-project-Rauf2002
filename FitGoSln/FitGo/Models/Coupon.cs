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
    
    public partial class Coupon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Start { get; set; }
        public Nullable<System.DateTime> Finish { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Code { get; set; }
    }
}
