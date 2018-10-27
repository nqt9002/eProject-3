namespace eProject3_Jamesthew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("package")]
    public partial class package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public package()
        {
            payments = new HashSet<payment>();
        }

        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string body { get; set; }

        public int price { get; set; }

        public int expirydate { get; set; }

        public bool is_public { get; set; }

        public int created_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment> payments { get; set; }
    }
}
