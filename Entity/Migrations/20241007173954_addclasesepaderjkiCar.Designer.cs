﻿// <auto-generated />
using System;
using Entity.EntityContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Entity.Migrations
{
    [DbContext(typeof(DbEntityContext))]
    [Migration("20241007173954_addclasesepaderjkiCar")]
    partial class addclasesepaderjkiCar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entity.Models.CarModels.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company_name");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("condition");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("price");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("Cars", "NewCar");
                });

            modelBuilder.Entity("Entity.Models.CarModels.CarCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("company_name");

                    b.HasKey("Id");

                    b.ToTable("CarCompanyNames", "FullCars");
                });

            modelBuilder.Entity("Entity.Models.CarModels.CarCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("condition");

                    b.HasKey("Id");

                    b.ToTable("CarCondition", "FullCars");
                });

            modelBuilder.Entity("Entity.Models.CarModels.CarModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.HasKey("Id");

                    b.ToTable("CarModel", "FullCars");
                });

            modelBuilder.Entity("Entity.Models.CarModels.CarType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("CarYears", "FullCars");
                });

            modelBuilder.Entity("Entity.Models.LoginModels.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nickname");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)")
                        .HasColumnName("password");

                    b.Property<int>("roleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("login", "auth");
                });

            modelBuilder.Entity("Entity.Models.LoginModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("role", "auth");
                });
#pragma warning restore 612, 618
        }
    }
}
