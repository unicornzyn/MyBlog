namespace MyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int id { get; set; }

        [Required]
        [StringLength(500)]
        public string content { get; set; }

        public bool isread { get; set; }

        public DateTime addtime { get; set; }
    }
}
