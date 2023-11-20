//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Converse.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class ProDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProDetail()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int ProDeID { get; set; }
        public int ProID { get; set; }
        public int SupID { get; set; }
        public int ColorID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public int SIZE { get; set; }
        public string SHAPE { get; set; }
        public string KEYWORD { get; set; }
        public double Price { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
    
        public virtual Color Color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size1 { get; set; }
        public virtual Supplier Supplier { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImg1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImg2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImg3 { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImg4 { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImg5 { get; set; }
    }
}