namespace eProject3_Jamesthew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class article_meta
    {
        public int id { get; set; }

        public int article_id { get; set; }

        [Column("_key")]
        [Required]
        [StringLength(250)]
        public string C_key { get; set; }

        [Column("_value")]
        [Required]
        public string C_value { get; set; }

        public virtual article article { get; set; }
    }
}
