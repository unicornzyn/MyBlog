namespace MyProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class R_ArticleTags
    {
        public int id { get; set; }

        public int articleid { get; set; }

        public int tagid { get; set; }

        public DateTime addtime { get; set; }
    }
}
