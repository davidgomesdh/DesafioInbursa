using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Loan> Proposta { get; set; }
        public DbSet<PaymentSchedule> PaymentFlowSummary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Loan>()
                .ToTable("Loan")
                .HasKey(l => l.LoanId);

            modelBuilder.Entity<Loan>()
                .Property(l => l.LoanAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Loan>()
                .Property(l => l.AnnualInterestRate)
                .HasColumnType("decimal(5,4)")
                .IsRequired();

            modelBuilder.Entity<Loan>()
                .Property(l => l.NumberOfMonths)
                .IsRequired();

            modelBuilder.Entity<Loan>()
                .HasMany(l => l.PaymentSchedules) // Define a coleção de PaymentSchedules
                .WithOne(p => p.Loan) // Relacionamento inverso (cada PaymentSchedule tem um Loan)
                .HasForeignKey(p => p.LoanId) // Chave estrangeira de PaymentSchedule
                .OnDelete(DeleteBehavior.Cascade); // Definição do comportamento de exclusão

            modelBuilder.Entity<PaymentSchedule>()
                .ToTable("PaymentSchedule")
                .HasKey(p => p.PaymentScheduleId);

            modelBuilder.Entity<PaymentSchedule>()
                .Property(p => p.Principal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<PaymentSchedule>()
                .Property(p => p.Interest)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<PaymentSchedule>()
                .Property(p => p.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}