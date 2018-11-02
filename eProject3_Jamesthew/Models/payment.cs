namespace eProject3_Jamesthew.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("payment")]
    public partial class payment
    {
        public int id { get; set; }

        [Display(Name = "VIP Package")]
        public int package_id { get; set; }

        [Required]
        [Display(Name = "Card holder")]
        public string title { get; set; }

        [Display(Name = "Card number")]
        [DataType(DataType.CreditCard)]
        public int card_number { get; set; }

        [Required]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime card_expirydate { get; set; }

        [Required]
        [Display(Name = "CSC")]
        public int csc { get; set; }

        public int created_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public virtual package package { get; set; }

        public virtual user user { get; set; }
    }
}
