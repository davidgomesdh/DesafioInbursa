﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Loan", b =>
                {
                    b.Property<Guid>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AnnualInterestRate")
                        .HasColumnType("decimal(5,4)");

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberOfMonths")
                        .HasColumnType("int");

                    b.HasKey("LoanId");

                    b.ToTable("Loan", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.PaymentSchedule", b =>
                {
                    b.Property<Guid>("PaymentScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Interest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("LoanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<decimal>("Principal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PaymentScheduleId");

                    b.HasIndex("LoanId");

                    b.ToTable("PaymentSchedule", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.PaymentSchedule", b =>
                {
                    b.HasOne("Domain.Entity.Loan", "Loan")
                        .WithMany("PaymentSchedules")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Domain.Entity.Loan", b =>
                {
                    b.Navigation("PaymentSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
