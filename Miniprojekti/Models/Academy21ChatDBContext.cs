using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Miniprojekti.Models
{
    public partial class Academy21ChatDBContext : DbContext
    {
        public Academy21ChatDBContext()
        {
        }

        public Academy21ChatDBContext(DbContextOptions<Academy21ChatDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=academy21charserver.database.windows.net;database=Academy21ChatDB;user=Konsultti;password=KonsultinPwd123?");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("Message_Id");

                entity.Property(e => e.Category).HasMaxLength(20);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.FromPersonId).HasColumnName("From_Person_Id");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.SendTime).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ToPersonId).HasColumnName("To_Person_Id");

                entity.HasOne(d => d.FromPerson)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.FromPersonId)
                    .HasConstraintName("FK_Message_Person");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId).HasColumnName("Person_Id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Hometown).HasMaxLength(50);

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
