namespace MyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reply")]
    public partial class Reply
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public int Rid { get; set; }

        [Required]
        [StringLength(100)]
        public string Nick { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        public DateTime AddTime { get; set; }
    }
}
