﻿// <auto-generated />
using DataBases.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kursach.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241210185805_1")]
    partial class _1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vhod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<float>("Kbe")
                        .HasColumnType("real");

                    b.Property<double>("Kd")
                        .HasColumnType("float");

                    b.Property<float>("Khb")
                        .HasColumnType("real");

                    b.Property<int>("Kr")
                        .HasColumnType("int");

                    b.Property<float>("Shir")
                        .HasColumnType("real");

                    b.Property<int>("T1")
                        .HasColumnType("int");

                    b.Property<string>("hardness")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sigmaHP")
                        .HasColumnType("int");

                    b.Property<string>("typeshi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("u")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Vhods");
                });

            modelBuilder.Entity("Vyhod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("Re")
                        .HasColumnType("real");

                    b.Property<int>("VhodId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VhodId")
                        .IsUnique();

                    b.ToTable("Vyhods");
                });

            modelBuilder.Entity("Vyhod", b =>
                {
                    b.HasOne("Vhod", "vhod")
                        .WithOne("vyhod")
                        .HasForeignKey("Vyhod", "VhodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("vhod");
                });

            modelBuilder.Entity("Vhod", b =>
                {
                    b.Navigation("vyhod")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
