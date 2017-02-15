namespace MyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tags
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string tname { get; set; }

        public int sort { get; set; }

        public DateTime addtime { get; set; }
    }
}
