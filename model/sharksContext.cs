using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace postgresql.model
{
    public partial class sharksContext : DbContext
    {
        public sharksContext()
        {
        }

        public sharksContext(DbContextOptions<sharksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Spil> Spil { get; set; }
        public virtual DbSet<Spiller> Spiller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=10.0.0.21;Database=sharks;Username=brian;Password=brian123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("score");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval(('\"score_id_seq\"'::text)::regclass)");

                entity.Property(e => e.FkSpil).HasColumnName("fk_spil");

                entity.Property(e => e.FkSpiller).HasColumnName("fk_spiller");

                entity.Property(e => e.Score1).HasColumnName("score");

                entity.HasOne(d => d.FkSpilNavigation)
                    .WithMany(p => p.Score)
                    .HasForeignKey(d => d.FkSpil)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("score_fk_spil_fkey");

                entity.HasOne(d => d.FkSpillerNavigation)
                    .WithMany(p => p.Score)
                    .HasForeignKey(d => d.FkSpiller)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("score_fk_spiller_fkey");
            });

            modelBuilder.Entity<Spil>(entity =>
            {
                entity.ToTable("spil");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval(('\"spil_id_seq\"'::text)::regclass)");

                entity.Property(e => e.Betaler).HasColumnName("betaler");

                entity.Property(e => e.DatoOprettet)
                    .HasColumnName("dato_oprettet")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.DatoSpil)
                    .HasColumnName("dato_spil")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Pris).HasColumnName("pris");

                entity.HasOne(d => d.BetalerNavigation)
                    .WithMany(p => p.Spil)
                    .HasForeignKey(d => d.Betaler)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("spil_betaler_fkey");
            });

            modelBuilder.Entity<Spiller>(entity =>
            {
                entity.ToTable("spiller");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval(('\"spiller_id_seq\"'::text)::regclass)");

                entity.Property(e => e.Navn)
                    .HasColumnName("navn")
                    .HasMaxLength(50);
            });

            modelBuilder.HasSequence("score_id_seq");

            modelBuilder.HasSequence("spil_id_seq");

            modelBuilder.HasSequence("spiller_id_seq");
        }
    }
}
