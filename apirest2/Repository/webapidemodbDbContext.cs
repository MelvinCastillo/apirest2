using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using apirestcore31.Repository.Models;


namespace apirestcore31.Repository
{
    public partial class webapidemodbDbContext : DbContext
    {
        public webapidemodbDbContext()
        {
        }

        public webapidemodbDbContext(DbContextOptions<webapidemodbDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Usuarios1> Usuarios1s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
            {
// To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              // Connectionstring to connect a sql server azure Database 
                optionsBuilder.UseSqlServer("Data Source=melvindb.database.windows.net,1433;Initial Catalog=global;User Id=sa1;Password=Greysy123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.Property(e => e.ProfessorId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Teaches).IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.RollNumber).IsUnicode(false);

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Professors_Students");
            });

            modelBuilder.Entity<Usuarios1>(entity =>
            {
                entity.Property(e => e.Usuarioid).IsUnicode(false);

                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
