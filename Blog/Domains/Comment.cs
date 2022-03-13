namespace Blog.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        [StringLength(225,ErrorMessage ="Tối đa 225 kí tự !")]
        [Display(Name ="")]
        public string Name { get; set; }
        [Display(Name = "Email")]

        public string Email { get; set; }

        public string CommentHeader { get; set; }

        [StringLength(225,ErrorMessage="Tối đa 225 kí tự !")]
        [Display(Name = "Nội dung")]

        public string CommentText { get; set; }

        [Display(Name = "Ngày đăng")]

        public DateTime? CommentTime { get; set; }

        public int? PostId { get; set; }
        [Display(Name = "Trạng thái")]

        public byte? Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedOn { get; set; }

        public virtual Post Post { get; set; }
    }
}
