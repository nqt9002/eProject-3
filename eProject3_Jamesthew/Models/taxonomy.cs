namespace eProject3_Jamesthew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("taxonomy")]
    public partial class taxonomy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taxonomy()
        {
            taxonomy_m2m = new HashSet<taxonomy_m2m>();
            taxonomy_meta = new HashSet<taxonomy_meta>();
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

        public int created_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taxonomy_m2m> taxonomy_m2m { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taxonomy_meta> taxonomy_meta { get; set; }

        public virtual user user { get; set; }
    }
}
