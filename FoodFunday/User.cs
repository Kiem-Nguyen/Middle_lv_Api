//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodFunday
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string avartar { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public Nullable<bool> sex { get; set; }
        public string token { get; set; }
        public string colorthame { get; set; }
        public Nullable<int> type { get; set; }
    
        public virtual UserType UserType { get; set; }
    }
}
