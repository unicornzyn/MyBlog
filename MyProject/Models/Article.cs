namespace MyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string title { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        public string contenthtml { get; set; }

        public DateTime addtime { get; set; }
    }
}
