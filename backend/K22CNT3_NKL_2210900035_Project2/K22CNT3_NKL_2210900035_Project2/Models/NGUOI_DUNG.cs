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
    
    public partial class NGUOI_DUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOI_DUNG()
        {
            this.COMMENTs = new HashSet<COMMENT>();
            this.STORies = new HashSet<STORY>();
        }
    
        public int ma_nguoi_dung { get; set; }
        public string ten_dang_nhap { get; set; }
        public string mat_khau { get; set; }
        public string email { get; set; }
        public System.DateTime ngay_dang_ky { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT> COMMENTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STORY> STORies { get; set; }
    }
}
