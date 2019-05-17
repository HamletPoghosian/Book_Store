﻿// <auto-generated />
using System;
using Book_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Book_Store.Migrations
{
    [DbContext(typeof(BookDBContext))]
    [Migration("20190517070713_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Book_Store.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Popular");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("BookItems");
                });
#pragma warning restore 612, 618
        }
    }
}