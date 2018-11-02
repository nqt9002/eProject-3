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
        [Display(Name ="Title")]
        public string title { get; set; }

        [Required]
        [Display(Name ="Description")]
        public string body { get; set; }

        [Display(Name ="Price")]
        public int price { get; set; }

        [Required]
        [Display(Name ="Expriry date")]
        public int expirydate { get; set; }

        [Display(Name ="Is public")]
        public bool is_public { get; set; }

        [Display(Name = "Create by")]
        public int created_by { get; set; }

        [Display(Name = "Create at")]
        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment> payments { get; set; }
    }
}
