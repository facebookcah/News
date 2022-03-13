namespace Blog.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Comments = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [StringLength(500,ErrorMessage ="Tối đa 500 kí tự !")]
        [Display(Name = "Tiêu đề")]

        public string Title { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string PostContent { get; set; }

        [StringLength(225)]
        public string UrlSlug { get; set; }
        [Display(Name = "Trạng thái")]

        public bool? Published { get; set; }
        [Display(Name = "Ngày đăng")]

        public DateTime PostedOn { get; set; }

        public DateTime? Modifiled { get; set; }

        [Display(Name = "Lượt xem")]

        public int? ViewCount { get; set; }
        [Display(Name = "Lượt đánh giá")]

        public int? RateCount { get; set; }

        public int? TotalRate { get; set; }
        [Display(Name = "Tiêu đề bài viết")]

        public int? CategoryId { get; set; }
       

        public byte? Status { get; set; }
        [Display(Name = "Ngày tạo")]

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Ngày cập nhật")]

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedOn { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
