namespace Blog.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tag()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [StringLength(225,ErrorMessage ="Tối đã 225 kí tự !")]
        [Display(Name = "Tag")]

        public string TagName { get; set; }

        [StringLength(225)]
        public string UrlSlug { get; set; }

        [StringLength(1024, ErrorMessage = "Tối đã 1024 kí tự !")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public int? Count { get; set; }
        [Display(Name = "Trạng thái")]

        public byte? Status { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày tạo")]

        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày cập nhật")]

        public DateTime? UpdatedOn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
