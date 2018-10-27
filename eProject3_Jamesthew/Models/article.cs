namespace eProject3_Jamesthew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("article")]
    public partial class article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public article()
        {
            article_meta = new HashSet<article_meta>();
            feedbacks = new HashSet<feedback>();
            taxonomy_m2m = new HashSet<taxonomy_m2m>();
        }

        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string body { get; set; }

        [Required]
        public string excerpt { get; set; }

        [Required]
        [StringLength(250)]
        public string content_type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? published_at { get; set; }

        public int created_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<article_meta> article_meta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taxonomy_m2m> taxonomy_m2m { get; set; }
    }
}
