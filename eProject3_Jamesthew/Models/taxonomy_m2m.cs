namespace eProject3_Jamesthew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class taxonomy_m2m
    {
        public int id { get; set; }

        public int article_id { get; set; }

        public int taxonomy_id { get; set; }

        public int created_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public virtual article article { get; set; }

        public virtual taxonomy taxonomy { get; set; }

        public virtual user user { get; set; }
    }
}
