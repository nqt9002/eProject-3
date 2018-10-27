namespace eProject3_Jamesthew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            articles = new HashSet<article>();
            feedbacks = new HashSet<feedback>();
            packages = new HashSet<package>();
            payments = new HashSet<payment>();
            taxonomies = new HashSet<taxonomy>();
            taxonomy_m2m = new HashSet<taxonomy_m2m>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "UserName cannot be blank")]
        [Display(Name = "UserName:")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "UserName must be between 5 - 50")]
        public string username { get; set; }

        [Column("_password")]
        [Required(ErrorMessage = "Password cannot be blank")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        [StringLength(32, MinimumLength = 5, ErrorMessage = "PassWord must be between 5 - 32")]
        public string _password { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [Display(Name = "Email: ")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "VIP Expiry Date: ")]
        public DateTime? package_expirydate { get; set; }

        [Display(Name = "Is admin: ")]
        public bool is_admin { get; set; }

        [Display(Name = "Is active: ")]
        public bool is_active { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<article> articles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<package> packages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment> payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taxonomy> taxonomies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taxonomy_m2m> taxonomy_m2m { get; set; }
    }
}
