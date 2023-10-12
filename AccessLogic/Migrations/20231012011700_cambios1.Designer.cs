﻿// <auto-generated />
using System;
using AccessLogic.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccessLogic.Migrations
{
    [DbContext(typeof(EcosystemContext))]
    [Migration("20231012011700_cambios1")]
    partial class cambios1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Conservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Security")
                        .HasColumnType("int")
                        .HasColumnName("Rango de seguridad");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Estado");

                    b.HasKey("Id");

                    b.ToTable("Conservation");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alpha3")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Código alfa-3");

                    b.Property<int?>("EcosystemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Alpha3")
                        .IsUnique();

                    b.HasIndex("EcosystemId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Entities.Ecosystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Área");

                    b.Property<string>("GeoDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ubicación");

                    b.Property<string>("ImgRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagen");

                    b.HasKey("Id");

                    b.ToTable("Ecosystems");
                });

            modelBuilder.Entity("Domain.Entities.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CientificName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cientific name");

                    b.Property<string>("ImgRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Image");

                    b.Property<decimal>("LongRangeAdultMax")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Max length");

                    b.Property<decimal>("LongRangeAdultMin")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Min length");

                    b.Property<decimal>("WeightRangeMax")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Max weight");

                    b.Property<decimal>("WeightRangeMin")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Min weight");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("Domain.Entities.Threat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Danger")
                        .HasColumnType("int")
                        .HasColumnName("Nivel de peligrosidad");

                    b.Property<int?>("EcosystemId")
                        .HasColumnType("int");

                    b.Property<int?>("SpeciesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EcosystemId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Threats");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha de registro");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EcosystemSpecies", b =>
                {
                    b.Property<int>("EcosystemsId")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.HasKey("EcosystemsId", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("EcosystemSpecies");
                });

            modelBuilder.Entity("Domain.Entities.Conservation", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Name", "ConservationName", b1 =>
                        {
                            b1.Property<int>("ConservationId")
                                .HasColumnType("int");

                            b1.Property<int>("MaxLength")
                                .HasColumnType("int");

                            b1.Property<int>("MinLength")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("ConservationId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Conservation");

                            b1.WithOwner()
                                .HasForeignKey("ConservationId");
                        });

                    b.Navigation("ConservationName")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.HasOne("Domain.Entities.Ecosystem", null)
                        .WithMany("Countries")
                        .HasForeignKey("EcosystemId");

                    b.OwnsOne("Domain.ValueObjects.Name", "CountryName", b1 =>
                        {
                            b1.Property<int>("CountryId")
                                .HasColumnType("int");

                            b1.Property<int>("MaxLength")
                                .HasColumnType("int");

                            b1.Property<int>("MinLength")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("CountryId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.Navigation("CountryName")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Ecosystem", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Description", "EcoDescription", b1 =>
                        {
                            b1.Property<int>("EcosystemId")
                                .HasColumnType("int");

                            b1.Property<int>("MaxLength")
                                .HasColumnType("int");

                            b1.Property<int>("MinLength")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EcosystemId");

                            b1.ToTable("Ecosystems");

                            b1.WithOwner()
                                .HasForeignKey("EcosystemId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Name", "EcosystemName", b1 =>
                        {
                            b1.Property<int>("EcosystemId")
                                .HasColumnType("int");

                            b1.Property<int>("MaxLength")
                                .HasColumnType("int");

                            b1.Property<int>("MinLength")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("EcosystemId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Ecosystems");

                            b1.WithOwner()
                                .HasForeignKey("EcosystemId");
                        });

                    b.Navigation("EcoDescription")
                        .IsRequired();

                    b.Navigation("EcosystemName")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Species", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Description", "SpeciesDescription", b1 =>
                        {
                            b1.Property<int>("SpeciesId")
                                .HasColumnType("int");

                            b1.Property<int>("MaxLength")
                                .HasColumnType("int");

                            b1.Property<int>("MinLength")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SpeciesId");

                            b1.ToTable("Species");

                            b1.WithOwner()
                                .HasForeignKey("SpeciesId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Name", "SpeciesName", b1 =>
                        {
                            b1.Property<int>("SpeciesId")
                                .HasColumnType("int");

                            b1.Property<int>("MaxLength")
                                .HasColumnType("int");

                            b1.Property<int>("MinLength")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("SpeciesId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Species");

                            b1.WithOwner()
                                .HasForeignKey("SpeciesId");
                        });

                    b.Navigation("SpeciesDescription")
                        .IsRequired();

                    b.Navigation("SpeciesName")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Threat", b =>
                {
                    b.HasOne("Domain.Entities.Ecosystem", null)
                        .WithMany("Threats")
                        .HasForeignKey("EcosystemId");

                    b.HasOne("Domain.Entities.Species", null)
                        .WithMany("Threats")
                        .HasForeignKey("SpeciesId");

                    b.OwnsOne("Domain.ValueObjects.Description", "ThreatDescription", b1 =>
                        {
                            b1.Property<int>("ThreatId")
                                .HasColumnType("int");

                            b1.Property<int>("MaxLength")
                                .HasColumnType("int");

                            b1.Property<int>("MinLength")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ThreatId");

                            b1.ToTable("Threats");

                            b1.WithOwner()
                                .HasForeignKey("ThreatId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Name", "ThreatName", b1 =>
                        {
                            b1.Property<int>("ThreatId")
                                .HasColumnType("int");

                            b1.Property<int>("MaxLength")
                                .HasColumnType("int");

                            b1.Property<int>("MinLength")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("ThreatId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Threats");

                            b1.WithOwner()
                                .HasForeignKey("ThreatId");
                        });

                    b.Navigation("ThreatDescription")
                        .IsRequired();

                    b.Navigation("ThreatName")
                        .IsRequired();
                });

            modelBuilder.Entity("EcosystemSpecies", b =>
                {
                    b.HasOne("Domain.Entities.Ecosystem", null)
                        .WithMany()
                        .HasForeignKey("EcosystemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Species", null)
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Ecosystem", b =>
                {
                    b.Navigation("Countries");

                    b.Navigation("Threats");
                });

            modelBuilder.Entity("Domain.Entities.Species", b =>
                {
                    b.Navigation("Threats");
                });
#pragma warning restore 612, 618
        }
    }
}
