namespace GestionEchec
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1() : base("name=Model1")
        {

        }

        public virtual DbSet<CLUB> CLUB { get; set; }
        public virtual DbSet<JOUEUR> JOUEUR { get; set; }
        public virtual DbSet<PAYS> PAYS { get; set; }
        public virtual DbSet<VILLE> VILLE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLUB>()
                .Property(e => e.nomClub)
                .IsUnicode(false);

            modelBuilder.Entity<CLUB>()
                .HasMany(e => e.JOUEUR)
                .WithRequired(e => e.CLUB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JOUEUR>()
                .Property(e => e.nomJoueur)
                .IsUnicode(false);

            modelBuilder.Entity<JOUEUR>()
                .Property(e => e.prenomJoueur)
                .IsUnicode(false);

            modelBuilder.Entity<PAYS>()
                .Property(e => e.nomPays)
                .IsUnicode(false);

            modelBuilder.Entity<PAYS>()
                .HasMany(e => e.VILLE)
                .WithRequired(e => e.PAYS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VILLE>()
                .Property(e => e.nomVille)
                .IsUnicode(false);

            modelBuilder.Entity<VILLE>()
                .HasMany(e => e.CLUB)
                .WithRequired(e => e.VILLE)
                .WillCascadeOnDelete(false);
        }
    }
}
