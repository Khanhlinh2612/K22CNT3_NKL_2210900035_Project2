//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT3_NKL_2210900035_Project2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHAPTER
    {
        public int ma_chuong { get; set; }
        public int so_chuong { get; set; }
        public string ten_chuong { get; set; }
        public string noi_dung { get; set; }
        public System.DateTime ngay_dang { get; set; }
        public int ma_truyen { get; set; }
    
        public virtual STORY STORY { get; set; }
    }
}
