//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parish2_0
    {
        public int RegisterID { get; set; }
        public int PastorID { get; set; }
        public int CongregantID { get; set; }
    
        public virtual Congregant Congregant { get; set; }
        public virtual Pastor Pastor { get; set; }
    }
}
