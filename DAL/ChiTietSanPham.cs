//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBL3.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietSanPham()
        {
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }
    
        public int ID_CTSP { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> ID_LoaiHang { get; set; }
        public Nullable<int> size_id { get; set; }
        public Nullable<int> color_id { get; set; }
        public Nullable<int> ID_LoHang { get; set; }
        public int SoLuong { get; set; }
        public double Gia { get; set; }
<<<<<<< HEAD
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShoulDBeReadOnly")]
=======
        public Nullable<double> Gia_nhap { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
>>>>>>> 85abff1a886188270143c988969a866dbdb94731
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual Color Color { get; set; }
        public virtual LoaiHang LoaiHang { get; set; }
        public virtual LoHang LoHang { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual Size Size { get; set; }
    }
}
