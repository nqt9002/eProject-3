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
            taxonomies = new List<taxonomy>();
        }

        public int id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string body { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Short description")]
        public string excerpt { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Category")]
        public string content_type { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Published at")]
        public DateTime? published_at { get; set; }

        [Display(Name = "Created by")]
        public int created_by { get; set; }

        [Display(Name = "Created at")]
        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public virtual user user { get; set; }

        protected Dictionary<string, string> _meta;

        public Dictionary<string, string> metaData()
        {
            if (this._meta == null)
            {
                this._meta = new Dictionary<string, string>();
                foreach (var meta in this.article_meta)
                {
                    this._meta[meta.C_key] = meta.C_value;
                }
            }

            return this._meta;
        }

        public string getMeta(string key)
        {
            return this.metaData()[key];
        }

        public void setMeta(string key, string value)
        {
            // if create
            article_meta new_meta = new article_meta();
            new_meta.C_key = key;
            new_meta.C_value = value;
            this.article_meta.Add(new_meta);
        }

        public Boolean isPremium()
        {
            return this.getMeta("premium") == "true";
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<article_meta> article_meta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taxonomy_m2m> taxonomy_m2m { get; set; }

        public virtual ICollection<taxonomy> taxonomies { get; set; }
    }
}
