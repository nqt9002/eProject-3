namespace eProject3_Jamesthew.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Jamesthew_Model : DbContext
    {
        public Jamesthew_Model()
            : base("name=Jamesthew_Model")
        {
        }

        public virtual DbSet<article> articles { get; set; }
        public virtual DbSet<article_meta> article_meta { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<package> packages { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<taxonomy> taxonomies { get; set; }
        public virtual DbSet<taxonomy_m2m> taxonomy_m2m { get; set; }
        public virtual DbSet<taxonomy_meta> taxonomy_meta { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<article>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<article>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<article>()
                .Property(e => e.excerpt)
                .IsUnicode(false);

            modelBuilder.Entity<article>()
                .Property(e => e.content_type)
                .IsUnicode(false);

            modelBuilder.Entity<article>()
                .HasMany(e => e.article_meta)
                .WithRequired(e => e.article)
                .HasForeignKey(e => e.article_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<article>()
                .HasMany(e => e.feedbacks)
                .WithRequired(e => e.article)
                .HasForeignKey(e => e.article_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<article>()
                .HasMany(e => e.taxonomy_m2m)
                .WithRequired(e => e.article)
                .HasForeignKey(e => e.article_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<article_meta>()
                .Property(e => e.C_key)
                .IsUnicode(false);

            modelBuilder.Entity<article_meta>()
                .Property(e => e.C_value)
                .IsUnicode(false);

            modelBuilder.Entity<feedback>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<package>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<package>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<package>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.package)
                .HasForeignKey(e => e.package_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<taxonomy>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<taxonomy>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<taxonomy>()
                .Property(e => e.excerpt)
                .IsUnicode(false);

            modelBuilder.Entity<taxonomy>()
                .Property(e => e.content_type)
                .IsUnicode(false);

            modelBuilder.Entity<taxonomy>()
                .HasMany(e => e.taxonomy_m2m)
                .WithRequired(e => e.taxonomy)
                .HasForeignKey(e => e.taxonomy_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<taxonomy>()
                .HasMany(e => e.taxonomy_meta)
                .WithRequired(e => e.taxonomy)
                .HasForeignKey(e => e.taxonomy_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<taxonomy_meta>()
                .Property(e => e.C_key)
                .IsUnicode(false);

            modelBuilder.Entity<taxonomy_meta>()
                .Property(e => e.C_value)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e._password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.articles)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.created_by)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.feedbacks)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.created_by)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.packages)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.created_by)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.created_by)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.taxonomies)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.created_by)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.taxonomy_m2m)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.created_by)
                .WillCascadeOnDelete(false);
        }
    }
}
