﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace ProjekatBack.Migrations
{
    [DbContext(typeof(KaficContext))]
    partial class KaficContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Kafic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int")
                        .HasColumnName("Kapacitet");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<int>("X")
                        .HasColumnType("int")
                        .HasColumnName("X");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("Y");

                    b.HasKey("ID");

                    b.ToTable("Kafic");
                });

            modelBuilder.Entity("Models.Porudzbina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int")
                        .HasColumnName("Cena");

                    b.Property<int?>("KaficID")
                        .HasColumnType("int");

                    b.Property<int>("RedniBroj")
                        .HasColumnType("int")
                        .HasColumnName("RedniBroj");

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tip");

                    b.Property<int>("X")
                        .HasColumnType("int")
                        .HasColumnName("X");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("Y");

                    b.HasKey("ID");

                    b.HasIndex("KaficID");

                    b.ToTable("Porudzbina");
                });

            modelBuilder.Entity("Models.Sto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KaficID")
                        .HasColumnType("int");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int")
                        .HasColumnName("Kapacitet");

                    b.Property<int>("M")
                        .HasColumnType("int")
                        .HasColumnName("M");

                    b.Property<int>("MaxKapacitet")
                        .HasColumnType("int")
                        .HasColumnName("MaxKapacitet");

                    b.Property<int>("N")
                        .HasColumnType("int")
                        .HasColumnName("N");

                    b.HasKey("ID");

                    b.HasIndex("KaficID");

                    b.ToTable("Sto");
                });

            modelBuilder.Entity("Models.Porudzbina", b =>
                {
                    b.HasOne("Models.Kafic", "Kafic")
                        .WithMany("Porudzbine")
                        .HasForeignKey("KaficID");

                    b.Navigation("Kafic");
                });

            modelBuilder.Entity("Models.Sto", b =>
                {
                    b.HasOne("Models.Kafic", "Kafic")
                        .WithMany("Stolovi")
                        .HasForeignKey("KaficID");

                    b.Navigation("Kafic");
                });

            modelBuilder.Entity("Models.Kafic", b =>
                {
                    b.Navigation("Porudzbine");

                    b.Navigation("Stolovi");
                });
#pragma warning restore 612, 618
        }
    }
}